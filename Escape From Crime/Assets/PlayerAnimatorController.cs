using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
   
    //NOTE : LAZEM EL VARIABLES TKON ' PUBLIC ' 3SHAN ASHOFHA F UNITY ..


    public float moveSpeed; //how fast the character moves
    public float jumpHeight; //how hight the character jump

    public bool isFacingRight; //check if the character facing right
    public KeyCode Spacebar; //character will jump by click on the spacebar

    //KEYCODE Y3NY BUTTON F EL KEYBOARD
    public KeyCode L; //L is the name we gave a keyboard button we chose to be the left movement button
    public KeyCode R; //R is the name we gave a keyboard button we chose to be the right movement button

    public Transform groundCheck; //we use it to see if the player is touching the ground
    public float groundCheckRadius; //close ad eh to the ground

    public LayerMask whatIsGround; //this variable stores what is considred a ground to the character
    private bool grounded; //check if the character is standing on soild ground

    private Animator anim;

   

    public KeyCode s; //s is the name we gave a keyboard button we chose 3shan adrb naar 3la el enemy


    

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>(); //b3ml l el ' anim ' initialization f el start
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(Spacebar) && grounded) //When user presses the space buXon once
        {
            Jump();
        }
        if (Input.GetKey(L)) //When user presses the leY arrow buXon
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (isFacingRight) //eza bass ymeen
            {
                Flip(); //b3mlo flip
                isFacingRight = false; //w b5ly isFacingRight b false
            }
        }
        if (Input.GetKey(R)) //When user presses the right arrow buXon
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFacingRight) //eza msh bass ymeen
            {
                Flip(); //b3mlo flip
                isFacingRight = true; //w b5ly isFacingRight b true
            }
        }
        anim.SetBool("Grounded", grounded); //check if grounded true or falce, true: state Idel, false: state jump

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)); //bna5od el velocity bta3t el player w nohtha f el speed

    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}