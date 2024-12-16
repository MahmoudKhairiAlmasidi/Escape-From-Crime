using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController5 : MonoBehaviour 
{

    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;

    public void Flip(){
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "bullet"){
            FindObjectOfType<PlayerStats5>().TakeDamage(damage);
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