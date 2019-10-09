using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    LauchSpaceship lauch;
    AudioSource audio;

    void Start() {
        lauch = FindObjectOfType<LauchSpaceship>();
        audio = GetComponent<AudioSource>();
    }
   

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            lauch.GetFuel();
            audio.Play();
            this.gameObject.SetActive(false);

        }
    }

   
}
