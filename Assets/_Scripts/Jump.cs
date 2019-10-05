using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallMulti = 10f;
    [SerializeField] float lowJumpMulti = 2f;


    
    Rigidbody rb;
    int jumpCount = 0;
    private float distToGround;
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
        jumpForce *= 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
        print($"Distance to ground is {distToGround}");
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded()) {
            jumpCount = 0;
        }
        //print(IsGrounded());

        if (Input.GetKey(KeyCode.Space) && IsGrounded()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (canDoubleJump && Input.GetKey(KeyCode.Space)) {
                jumpCount++;
            }
            if (jumpCount < 2) {
                
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            
            
        }
        if (!IsGrounded()) {
            ModifyVelocityWhenJumping();
        }
        
    }

    private void ModifyVelocityWhenJumping() {
              
        if (rb.velocity.y < 0) {
            print("high multi");
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            print("Low multi");
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
        }
    }

    
    public  bool IsGrounded() {
        
        return Physics.Raycast(groundCheck.position, Vector3.down, distToGround + 0.1f);
        
        //return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.2f);
    }
}
