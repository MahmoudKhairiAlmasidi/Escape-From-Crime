using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats5 : MonoBehaviour
{
    public int health = 20;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(int damage)
    {
       
        
            this.health = this.health - damage;
            if (this.health < 0)
            {
                this.health = 0;
            }
            else if (this.health == 0)
            {
                Debug.Log("Mini boss is dead");
                Destroy(this.gameObject);
            }

    }

  
}
