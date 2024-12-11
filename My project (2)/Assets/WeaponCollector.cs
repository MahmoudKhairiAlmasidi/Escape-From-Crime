using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollector : MonoBehaviour
{
    private bool isNearWeapon = false; // Tracks if the player is near a weapon
    private GameObject weapon; // Reference to the nearby weapon
    private int weaponCount = 0; // Tracks the number of weapons collected
    private int weaponLimit = 5; // Maximum number of weapons the player can carry

    void Update()
    {
        // Check if the player presses "E" to pick up a weapon
        if (isNearWeapon && Input.GetKeyDown(KeyCode.E))
        {
            if (weaponCount < weaponLimit)
            {
                weaponCount++; // Increment weapon count
                Destroy(weapon); // Destroy the weapon in the scene
                Debug.Log($"Weapon picked up! Total weapons: {weaponCount}");
            }
            else
            {
                Debug.Log("Weapon limit reached! You can't carry more than 5 weapons.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the tag "weapon"
        if (other.CompareTag("weapon")) // Ensure tag matches "weapon"
        {
            isNearWeapon = true; // Player is near the weapon
            weapon = other.gameObject; // Store reference to the weapon
            Debug.Log("Press E to pick up the weapon.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When the player moves away from the weapon
        if (other.CompareTag("weapon")) // Ensure tag matches "weapon"
        {
            isNearWeapon = false; // Player is no longer near a weapon
            weapon = null; // Clear weapon reference
            Debug.Log("Left weapon pickup range.");
        }
    }
}
