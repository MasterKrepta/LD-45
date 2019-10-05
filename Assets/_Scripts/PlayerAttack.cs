using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] float attackDelay = .6f;
    bool canAttack = true;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && canAttack) {
            canAttack = false;
            Attack();
        }
    }

    void Attack() {
        print("attack");
        anim.SetTrigger("Attack");
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown() {
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
