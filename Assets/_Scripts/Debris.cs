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
    AudioSource audio;
    [SerializeField]AudioClip pickup;
    [SerializeField] AudioClip throwEffect;


    void Start() {
        GetComponent<Renderer>().material = Colors[Random.Range(0, Colors.Length)];
        collider = GetComponent<BoxCollider>();
        triggerCol = GetComponent<SphereCollider>();
        triggerCol.isTrigger = true;
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }
    public void Pickup(Transform hand) {
        audio.clip = pickup;
        audio.Play();

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
        audio.clip = throwEffect;
        audio.Play();

        this.gameObject.transform.SetParent(null);
        rb.useGravity = true;
        collider.enabled = true;
        triggerCol.enabled = true;
    }

    void OnTriggerEnter(Collider other) {
        
        if (rb.velocity.magnitude > 0 && other.CompareTag("Enemy")) {
            //print($"{other.name} has been distracted by the brick");
            other.gameObject.GetComponent<ICanDetect>().React(transform);

        }
    }
  
    

  
}
