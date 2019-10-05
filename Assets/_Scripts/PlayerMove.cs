using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 15f;
    [SerializeField] float RotateSpeed = 15f;
    Rigidbody rb;
    Jump jump;
    Vector3 movement;
   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = GetInput();

    }

    void FixedUpdate() {
        //if (jump.IsGrounded()) {

            MovePlayer();
            if (rb.velocity != Vector3.zero) {
                RotatePlayer();
            }
        //}

       
    }

    private Vector3 GetInput() {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void RotatePlayer() {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * RotateSpeed);
 
    }

    private void MovePlayer() {
        
            rb.velocity = movement * MoveSpeed;
        
        
    }
}
