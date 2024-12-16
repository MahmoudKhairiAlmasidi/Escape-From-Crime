using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{

void FixedUpdate()
   {
    if(this.isFacingRight == true)
    {
        this.GetComponent<Rigidbody2D>().velocity =
new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
    }
    else 
    {
    this.GetComponent<Rigidbody2D>().velocity =
    new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
    }
   }

   void OnTriggerEnter2D(Collider2D collider)
   {
    if(collider.tag == "Wall")
    {
        Flip();
    }
    else if (collider.tag == "Enemy")
    {
      Flip();
    }
    if(collider.tag == "Player")
    {
        FindObjectOfType<PlayerStatslevel2>().TakeDamage(damage);
      Flip();
    }
   }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}