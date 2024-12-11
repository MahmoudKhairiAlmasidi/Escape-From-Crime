using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
    public GameObject currentcheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer(){
        FindObjectOfType<NewBehaviourScript>().transform.position=currentcheckpoint.transform.position;
    
    }
}