using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyWalk : EnemyController
{
    private bool canFlip = true; // Flag to control flipping

    void FixedUpdate()
    {
        if (isFacingRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && canFlip)
        {
            if (collider.CompareTag("Wall") || collider.CompareTag("Enemy"))
            {
                Flip();
                StartCoroutine(FlipCooldown());
            }
            else if (collider.CompareTag("Player"))
            {
                Debug.Log("Player collision");
                FindObjectOfType<PlayerStatss>().TakeDamage(damage);
            }
        }
    }

    IEnumerator FlipCooldown()
    {
        canFlip = false;
        yield return new WaitForSeconds(1.0f); // Adjust the cooldown duration as needed
        canFlip = true;
    }
}
