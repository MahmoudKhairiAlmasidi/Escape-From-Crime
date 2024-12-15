using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keylevel2 : MonoBehaviour
{
      public int coinValue = 1; // Value of the coin (you can set this in the Unity Inspector)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the coin is the player
        PlayerStats1 playerStats1 = other.GetComponent<PlayerStats1>();
        if (playerStats1 != null)
        {
            playerStats1.CollectCoin(coinValue); // Add the coin's value to the player's total
            Destroy(gameObject); // Destroy the coin after it is collected
        }
    }

}
