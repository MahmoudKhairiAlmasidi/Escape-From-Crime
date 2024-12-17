using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform4 : MonoBehaviour
{

    public Transform PosA,PosB;
    public int Speed;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        targetPos=PosB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,PosA.position) < .1f ) targetPos = PosB.position;
        if(Vector2.Distance(transform.position,PosB.position) < .1f ) targetPos = PosA.position;
    
     transform.position=Vector2.MoveTowards(transform.position,targetPos,Speed* Time.deltaTime);
    
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.CompareTag("omar")){

            collision.transform.SetParent(this.transform);

        }
    }

     private void OnTriggerExit2D(Collider2D collision){

        if(collision.CompareTag("omar")){

            collision.transform.SetParent(null);
            
        }
    }
}
