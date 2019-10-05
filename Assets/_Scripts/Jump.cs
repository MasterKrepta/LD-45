using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallMulti = 10f;
    [SerializeField] float lowJumpMulti = 2f;


    Rigidbody rb;
    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        //print(IsGrounded());

        if (Input.GetKey(KeyCode.Space) && IsGrounded()) {
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
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
        
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
