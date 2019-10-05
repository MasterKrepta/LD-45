using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHasHealth
{
    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set ; }
    public float FlashDelay { set => throw new System.NotImplementedException(); }

    public void Die() {
        throw new System.NotImplementedException();
    }

    

    public void TakeDamage(float dmg) {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
