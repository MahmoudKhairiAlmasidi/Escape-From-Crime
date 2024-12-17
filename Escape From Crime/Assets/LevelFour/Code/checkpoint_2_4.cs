
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint_2_4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter2D(Collider2D other)
    {

     if (other.tag=="omar")
     FindObjectOfType<LevelManager4>().CurrentCheckpoint = this.gameObject;
    }
}