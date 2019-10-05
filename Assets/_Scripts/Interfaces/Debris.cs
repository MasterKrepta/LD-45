using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour, IInteractable
{
    BoxCollider collider;
    SphereCollider triggerCol;
    Rigidbody rb;
    [SerializeField] float thowForce = 10f;
    [SerializeField] float upForce = 5f;
    [SerializeField] Material[] Colors;


    void Start() {
        GetComponent<Renderer>().material = Colors[Random.Range(0, Colors.Length)];
        collider = GetComponent<BoxCollider>();
        triggerCol = GetComponent<SphereCollider>();
        triggerCol.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        
    }
    public void Pickup(Transform hand) {
        
        rb.velocity = Vector3.zero;
        transform.position = hand.position;
        transform.SetParent(hand);

        collider.enabled = false;
        triggerCol.enabled = false;
        rb.useGravity = false;
    }

    public void Use() {
        rb.AddForce(transform.parent.up * upForce, ForceMode.Impulse);
        rb.AddForce(transform.parent.forward * thowForce, ForceMode.Impulse);
        
        this.gameObject.transform.SetParent(null);
        rb.useGravity = true;
        collider.enabled = true;
        triggerCol.enabled = true;
    }

  

  
}
