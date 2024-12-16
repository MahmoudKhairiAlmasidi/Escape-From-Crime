using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcontrol : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;

    
    public Transform firepoint;
    public GameObject bullet;
    

    private bool facingLeft = true; // Track player direction
    private bool canShoot = true; // Flag to control shooting cooldown
    public float shootCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            facingLeft = true; // Update direction

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            facingLeft = false; // Update direction

            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("grounded", grounded);

        if (Input.GetKeyDown("x")&& canShoot) // Fire when 'a' is pressed
        {
            Shoot();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
       
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }


public void ChangeBullet(GameObject newBullet)
    {
       bullet  = newBullet; // Update the current bullet prefab
    }
    
    
    public void Shoot()
    {
        GameObject firedBullet = Instantiate(bullet, firepoint.position, firepoint.rotation);

        // Adjust bullet speed based on facing direction
        bulletcontroller5 bulletController = firedBullet.GetComponent<bulletcontroller5>();
        bulletController.speed = facingLeft ? -Mathf.Abs(bulletController.speed) : Mathf.Abs(bulletController.speed);
    
    canShoot = false;
        StartCoroutine(ShootCooldown());
    }

   private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown); // Wait for the cooldown duration
        canShoot = true; // Re-enable shooting
    }
}