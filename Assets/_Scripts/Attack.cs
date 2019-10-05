using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] PlayerHealth Target;
    [SerializeField] float attackDelay = 1.2f;
    bool canAttack = true;
    Animator anim;
    [SerializeField] float dmgAmount = 1f;


    public void Start() {
        anim = GetComponent<Animator>();
        if (Target == null) {
            Target = FindObjectOfType<PlayerHealth>();
        }
    }

    void AttackPlayer() {
        print("Attacking from attack script");
        //Target.TakeDamage(dmgAmount); //TODO move this to the final animation
        anim.SetTrigger("Attack");
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
