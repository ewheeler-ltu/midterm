using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject spawn;

    public float walkSpeed;
    public float startupSpeed;

    public float mach1Speed;

    public float jump;
    
    public float direction = -1;
    
    public bool max = false;

    private bool isGrounded;
    private bool doubleJump;
    private Rigidbody2D rb;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        transform.position = spawn.transform.position;
    }

    void Update() {
        //walking
        if(Input.GetButton("Horizontal") && !Input.GetKey("left shift")) {
            direction = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(direction * walkSpeed, rb.velocity.y);
            max = false;
        }

        //running
        if(Input.GetKey("left shift")) {
            //starting up
            if(Math.Abs(rb.velocity.x) < mach1Speed) {
                rb.velocity = new Vector2(rb.velocity.x + (direction * startupSpeed * Time.deltaTime), rb.velocity.y);
                max = false;
            //Mach 1
            } else {
                max = true;
                rb.velocity = new Vector2(direction * mach1Speed, rb.velocity.y);
            }
        }

        //jumping
        if(Input.GetKeyDown("z") && isGrounded) {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if(Input.GetKeyDown("z") && !isGrounded && doubleJump) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            doubleJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Ground")) {
            isGrounded = true;
            doubleJump = true;
        }

        if(other.collider.CompareTag("Death")) {
            transform.position = spawn.transform.position;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}
