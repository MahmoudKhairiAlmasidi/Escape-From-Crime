using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking5 : EnemyController5
{

    void FixedUpdate (){
        if(this.isFacingRight == true){
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    void OnTriggerEnter2D(Collider2D collider) {
            if(collider.tag == "wall"){
                Flip();
            }
            else if (collider.tag == "Enemy"){
                Flip();
            }
            if(collider.tag == "Player"){
                FindObjectOfType<PlayerStats5>().TakeDamage(damage);
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