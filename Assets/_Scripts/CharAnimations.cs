using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimations : MonoBehaviour
{

    [SerializeField] GameObject playerAttack;
    public void PlayerAttack_ON() {
        playerAttack.GetComponent<CauseDamage>().enabled = true;
    }
    public void PlayerAttack_OFF() {
        playerAttack.GetComponent<CauseDamage>().enabled = false;
    }
}
