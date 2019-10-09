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
    Animator anim;
    Vector3 movement;

    void OnEnable() {
        Events.OnRearAquired += EnableDoubleSpeed;
    }

    void OnDisable() {
        Events.OnRearAquired -= EnableDoubleSpeed;
    }

    private void EnableDoubleSpeed() {

        MoveSpeed *= 1.5f;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = GetComponent<Jump>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        movement = GetInput();
        MovePlayer();
        RotatePlayer();

    }

  
    private Vector3 GetInput() {
        return new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, 0, Input.GetAxis("Vertical") * MoveSpeed);
    }

    private void RotatePlayer() {
        if (movement != Vector3.zero) {
            anim.SetBool("Moving", true);
            transform.rotation = Quaternion.LookRotation(movement);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * RotateSpeed);
        }
        else {
            anim.SetBool("Moving", false);
        }


    }

    private void MovePlayer() {

        transform.Translate(movement * MoveSpeed * Time.deltaTime, Space.World);

        //movement.y = rb.velocity.y;
        
        //rb.velocity = movement * Time.deltaTime;
        //rb.AddForce(movement * MoveSpeed );


    }
}
