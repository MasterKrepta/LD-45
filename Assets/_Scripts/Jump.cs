using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallMulti = 10f;
    [SerializeField] float lowJumpMulti = 2f;

    Rigidbody rb;
    Animator anim;
    int jumpCount = 0;
    [SerializeField] float distToGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] bool grounded;
    [SerializeField]bool canDoubleJump = false;

    void OnEnable() {
        Events.OnCockpitAquired += EnableDoubleJump;
    }

    void OnDisable() {
        Events.OnCockpitAquired -= EnableDoubleJump;
    }

    private void EnableDoubleJump() {
        canDoubleJump = true;
        distToGround += .5f; //TODO THIS IS A HACK
        //jumpForce *= 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
        //print($"Distance to ground is {distToGround}");
    }

    void FixedUpdate() {
        grounded = IsGrounded();
        //print("Grounded " + grounded);
    }
    // Update is called once per frame
    void Update()
    {
     

        if (grounded) {
            jumpCount = 0;
        }
        //print(IsGrounded());

        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            anim.SetTrigger("Jump");
            
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
        if (canDoubleJump && Input.GetKeyDown(KeyCode.Space)) {

            jumpCount++;
            if (jumpCount < 2) {
                anim.SetTrigger("Jump");
                
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

            }
        }
        if (!grounded) {
            ModifyVelocityWhenJumping();
        }
        
    }

    private void ModifyVelocityWhenJumping() {
              
        if (rb.velocity.y < 0) {
            
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
        }
    }


    void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Ground")) {
            grounded = true;
        }
    }
    void OnCollisionExit(Collision other) {
        if (other.collider.CompareTag("Ground")) {
            grounded = false;
        }
    }


    public  bool IsGrounded() {
        return grounded;
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
        
        //return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.2f);
    }


    //************************************************************
  
}
