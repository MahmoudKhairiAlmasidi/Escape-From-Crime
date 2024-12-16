using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettersevel2 : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStatslevel2 playerStats = collision.gameObject.GetComponent<PlayerStatslevel2>();
            if (playerStats != null)
            {
                playerStats.ActivateLetter();
                Destroy(gameObject); // Destroy the clock object after it's collected
            }
        }
    }
}
