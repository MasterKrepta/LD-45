using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{

    [SerializeField] string Layer;
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Layer)) {
            other.GetComponent<IHasHealth>().TakeDamage(1);
        }
    }
}
