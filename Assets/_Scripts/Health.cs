using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHasHealth
{
    public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }
    float flashDelay = 0.25f;
    Renderer rend;
    Color original;


    void Start() {
        CurrentHealth = 5f;
        rend = GetComponent<Renderer>();
        original = rend.material.color;
    }

    public void Die() {
        Destroy(this.gameObject);
    }

    public void TakeDamage(float dmg) {
        CurrentHealth -= dmg;
        StartCoroutine(FlashOnHit());
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    IEnumerator FlashOnHit() {

        rend.material.color = Color.red;
        yield return new WaitForSeconds(flashDelay);
        rend.material.color = original;
    }
}



  
