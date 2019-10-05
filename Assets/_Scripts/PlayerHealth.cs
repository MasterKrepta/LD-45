using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHasHealth
{
   
    public float FlashDelay { set => throw new System.NotImplementedException(); }

    public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }
    float flashDelay = 0.25f;
    [SerializeField]Renderer[] rends;
    [SerializeField]Color[] originals;


    void Start() {
        CurrentHealth = 5f;
        rends = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < rends.Length; i++) {
            originals[i] = rends[i].material.color;
        }

    }

    public void Die() {
        print("Game Over, we died");
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (var script in scripts) {
            script.enabled = false;
        }
    }

    public void TakeDamage(float dmg) {
        CurrentHealth -= dmg;
        StartCoroutine(FlashOnHit());
        if (CurrentHealth <= 0) {
            Die();
        }
    }

    IEnumerator FlashOnHit() {
        foreach (var rend in rends) {
            rend.material.color = Color.red;
            
            
        }
        yield return new WaitForSeconds(flashDelay);
        for (int i = 0; i < rends.Length; i++) {
            rends[i].material.color = originals[i];
        }

    }
}
