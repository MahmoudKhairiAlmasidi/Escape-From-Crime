using UnityEngine;

public class bulletpickup : MonoBehaviour
{
    public GameObject newBulletPrefab; // The new bullet prefab to be assigned

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player collects the bullet
        {
            charcontrol player = other.GetComponent<charcontrol>();
            if (player != null)
            {
                player.ChangeBullet(newBulletPrefab); // Call the method to change the bullet
                Destroy(gameObject); // Destroy the pickup object
            }
        }
    }
}