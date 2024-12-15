using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:Escape From Crime/Assets/LevelTwo/MonoBehaviour.cs
public class MonoBehaviour1 : MonoBehaviour2
=======
public class guardswalk : MonoBehaviour
>>>>>>> Stashed changes:Escape From Crime/Assets/LevelTwo/guardswalk.cs
{
    /// Start is called before the first frame update
  
    public float attackRange = 7f; // Range to attack the player
    // Damage dealt to the player
    public float sleepDuration = 2f; // Duration the dog sleeps after eating meat
    public Animator animator; // Reference to the Animator component
    public float moveSpeed = 3f; // Speed of the dog

  
    private bool isAttacking = false; // Flag to check if the dog is attacking
   
    private float attackTimer = 0f; // Timer for attacking
   
public float speed = 2.0f; // Movement speed
    public float moveDuration = 4.0f; // Duration of movement in one direction

    private float moveTimer; // Timer to track movement duration
    private bool movingLeft = true;
    public float attackDuration = 5f;


    public AudioClip attacksound;
  


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
            
            Flip();
            moveTimer = moveDuration;
        }
      
        DetectPlayer();

      

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
        
        movingLeft = !movingLeft;
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


}
