using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    Spaceship spaceship;
    AudioSource audioSource;
 


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spaceship = FindObjectOfType<Spaceship>();
    }


    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            audioSource.Play();
            spaceship.InstallPart(this.gameObject);
        }
    }

}
