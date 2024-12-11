using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public float groundCheckRadius;
    public Transform groundCheck;
public LayerMask whatIsGround;
private bool grounded;
private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Spacebar) && grounded){
        Jump();
    }
    if(Input.GetKey(L)){
        GetComponent<Rigidbody2D>().velocity = new Vector2(-movespeed , GetComponent<Rigidbody2D>().velocity.y);
    if(GetComponent<SpriteRenderer>()!=null){
        GetComponent<SpriteRenderer>().flipX=true;
    }
    }
    if(Input.GetKey(R)){
        GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed , GetComponent<Rigidbody2D>().velocity.y);
if(GetComponent<SpriteRenderer>()!=null){
           
        GetComponent<SpriteRenderer>().flipX=false;
}
    }

   
  anim.SetFloat("speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }
    void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);

    }
    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, whatIsGround);
    }
    

}
