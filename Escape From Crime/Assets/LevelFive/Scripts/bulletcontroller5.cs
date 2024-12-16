using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller5 : MonoBehaviour
{
    public int damage=8;
    public float speed=10;
    private Rigidbody2D rb;
     
    
     
    
    
    //public AudioClip Scientistdamage;


    // Start is called before the first frame update
    void Start()
    {
        // Set bullet velocity based on the speed value
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        
       
        // Flip bullet sprite if moving left
        if (speed < 0)
        {
            transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure bullet continues moving at set speed
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("wall")){
            Destroy(this.gameObject);
        }

        else if (other.CompareTag("boss"))
        {   
           FindObjectOfType<EnemyStats5>().TakeDamage(damage);
            Destroy(gameObject);
        }

        

        
    }
}