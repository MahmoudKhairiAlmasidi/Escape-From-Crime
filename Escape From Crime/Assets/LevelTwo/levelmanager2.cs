using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager2 : MonoBehaviour
{
   public GameObject CurrentCheckpoint;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RespawnPlayer(){
    FindObjectOfType<PlayerControllelevel2>().transform.position= CurrentCheckpoint.transform.position;
    }

    public void RespawnEnemy(){
        Instantiate (enemy,transform.position ,transform.rotation );
    }
}
