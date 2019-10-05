using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Transform Hand;
    

    void Start() {
        
    }

    void OnTriggerStay(Collider other) {
        if (this.isActiveAndEnabled) {
            IInteractable usable = other.GetComponent<IInteractable>();
            if (usable != null && Input.GetKeyDown(KeyCode.E) && Hand.childCount == 0) {
                usable.Pickup(Hand);
                if (IsLaser(other.gameObject)) {
                    DisablePickup();
                }
            }
        }
        
    }

    private void DisablePickup() {
        this.enabled = false;
        
        
    }

   

    bool IsLaser(GameObject objectToPickup) {
        return objectToPickup.name == "Laser";
    }

}
