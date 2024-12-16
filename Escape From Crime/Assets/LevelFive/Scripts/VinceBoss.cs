using UnityEngine;
using System.Collections;

public class VinceBoss : MonoBehaviour {

    public float moveSpeed = 3f;
    public float attackRange = 2f;
    public int maxHealth = 200;
    public Transform[] patrolPoints;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f;

    private int currentHealth;
    private Transform player;
    private int currentPatrolIndex;
    private float nextFireTime;
    private Animator animator;

    private enum BossState { Patrolling, Chasing, Attacking, PhaseChange }
    private BossState currentState;

    void Start() {
        currentHealth = maxHealth;
        currentPatrolIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentState = BossState.Patrolling;
    }

    void Update() {
        switch (currentState) {
            case BossState.Patrolling:
                Patrol();
                break;
            case BossState.Chasing:
                ChasePlayer();
                break;
            case BossState.Attacking:
                AttackPlayer();
                break;
            case BossState.PhaseChange:
                PhaseChange();
                break;
        }
    }

    void Patrol() {
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f) {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }

        if (Vector2.Distance(transform.position, player.position) < attackRange * 2) {
            currentState = BossState.Chasing;
        }
    }

    void ChasePlayer() {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.position) <= attackRange) {
            currentState = BossState.Attacking;
        }
    }

    void AttackPlayer() {
        if (Time.time >= nextFireTime) {
            animator.SetTrigger("Attack");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
        if (Vector2.Distance(transform.position, player.position) > attackRange * 1.5f) {
            currentState = BossState.Chasing;
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        animator.SetTrigger("Hit");

        if (currentHealth <= maxHealth / 2 && currentState != BossState.PhaseChange) {
            currentState = BossState.PhaseChange;
        }

        if (currentHealth <= 0) {
            Die();
        }
    }

    void PhaseChange() {
        moveSpeed += 2f; // Speed up
        fireRate -= 0.5f; // Faster attacks
        animator.SetTrigger("Phase2");
        currentState = BossState.Chasing;
    }

    void Die() {
        animator.SetTrigger("Die");
        Destroy(gameObject, 2f); // Delay to allow death animation
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
} 
