using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviour1 : MonoBehaviour2
{
    // Start is called before the first frame update
    public GameObject meatPrefab; // Reference to the meat prefab
    public float detectionRange = 9f; // Range to detect meat
    public float attackRange = 7f; // Range to attack the player
    // Damage dealt to the player
    public float sleepDuration = 2f; // Duration the dog sleeps after eating meat
    public Animator animator; // Reference to the Animator component
    public float moveSpeed = 3f; // Speed of the dog

    private GameObject targetMeat; // Current target meat
    private bool isEating = false; // Flag to check if the dog is eating
    private bool isAttacking = false; // Flag to check if the dog is attacking
    public bool isDead = false; // Flag to check if the dog is dead
    private float attackTimer = 0f; // Timer for attacking
   
public float speed = 2.0f; // Movement speed
    public float moveDuration = 4.0f; // Duration of movement in one direction

    private float moveTimer; // Timer to track movement duration
    private bool movingLeft = true;
    public float attackDuration = 5f;


    public AudioClip attacksound;
    public AudioClip eat;


    void Start()
    {
        
            animator = GetComponent<Animator>();
            

        // Start the movement coroutine
        moveTimer = moveDuration;
        
    }

   
   

    void Update()
    {

        moveTimer -= Time.deltaTime;

        if (movingLeft)
        {
            // Move left
            MoveLeft();
        }
        else
        {
            // Move right
            MoveRight();
        }

        // Check if the move timer has reached zero
        if (moveTimer <= 0)
        {
            // Flip the dog and reset the move timer
            Flip();
            moveTimer = moveDuration;
        }
        if (isDead) return;

        DetectMeat();
        DetectPlayer();

        if (targetMeat != null && !isEating)
        {
            MoveToTarget(targetMeat.transform);
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= 1f) // Assuming attack animation duration is 1 second
            {
                
                attackTimer = 0f;
                isAttacking = false;
            }
        }
    }


private void MoveLeft()
    {
        // Set the velocity to move left
        GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // Flip the sprite to face left
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MoveRight()
    {
        // Set the velocity to move right
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // Flip the sprite to face right
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void Flip()
    {
        // Toggle the movement direction
        if(!isEating)
        movingLeft = !movingLeft;
    }



    void DetectMeat()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Meat"))
            {
                targetMeat = collider.gameObject;
                AudioManager.instance.PlaySingle(eat);
                return;
            }
        }
        targetMeat = null;
    }

    void DetectPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if (!isAttacking)
                {
                    StartCoroutine(StartAttack());
                }
                return;
            }
        }
        isAttacking = false;
        animator.SetBool("attack", false);
    }

    private IEnumerator StartAttack()
    {
       
        AudioManager.instance.PlaySingle(attacksound);
        isAttacking = true;
        animator.SetBool("attack", true);

        // Wait for the attack duration
        yield return new WaitForSeconds(attackDuration);

        // Reset the attack state
        isAttacking = false;
        animator.SetBool("attack", false);
    }

    void MoveToTarget(Transform target)
    {
        if (Vector2.Distance(transform.position, target.position) > 0.1f)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            if (target.gameObject.CompareTag("Meat"))
            {
                EatMeat(target.gameObject);
            }
            
        }
    }

    void EatMeat(GameObject meat)
    {
        isEating = true;
        animator.SetTrigger("eat");
        moveSpeed = 0f;
        Destroy(meat);
        Invoke("Sleep", 1f); // Assuming eat animation duration is 1 second
    }

    void Sleep()
    {
        animator.SetTrigger("sleep");
        Invoke("DestroySelf", sleepDuration);
    }

    void DestroySelf()
    {
        isDead = true;
        Destroy(gameObject);
    }

   
}