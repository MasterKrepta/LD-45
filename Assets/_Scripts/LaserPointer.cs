using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour, IInteractable
{
    [SerializeField] Transform RedDot;
    Rigidbody rb;
    BoxCollider collider;
    SphereCollider triggerCol;
    // Start is called before the first frame update
    void Start()
    {
        RedDot.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        triggerCol = GetComponent<SphereCollider>();
    }

   
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            print($"{other.name} saw the light");
            //TODO set up reaction, run for insects attract for animals
        }
    }

    public void Use() {

        if (RedDot.gameObject.activeSelf) {
            RedDot.gameObject.SetActive(false);
        }
        else {
            RedDot.gameObject.SetActive(true);
        }
        
    }

    public void Pickup(Transform hand) {
        transform.rotation = hand.rotation;
        
        rb.velocity = Vector3.zero;
        transform.position = hand.position;
        transform.SetParent(hand);

        collider.enabled = false;
        triggerCol.enabled = false;
        rb.useGravity = false;
    }


}
