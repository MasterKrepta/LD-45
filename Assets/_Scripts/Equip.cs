using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    Spaceship spaceship;

 


    // Start is called before the first frame update
    void Start()
    {
        spaceship = FindObjectOfType<Spaceship>();
    }


    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            spaceship.InstallPart(this.gameObject);
        }
    }

}
