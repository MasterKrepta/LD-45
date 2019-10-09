using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamage : MonoBehaviour
{

    [SerializeField] string Layer;
    void OnTriggerEnter(Collider other) {
        //print($"{this.name}  triggered {other.name}");
        if (other.CompareTag(Layer)) {
            //print(other.name);
            other.GetComponent<IHasHealth>().TakeDamage(1);
        }
    }
}
