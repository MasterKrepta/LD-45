using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    [SerializeField] Transform Hand;
    Animator anim;
    

    void Start() {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Hand.childCount == 1 && Input.GetKeyDown(KeyCode.T)) {
            anim.SetTrigger("Attack");
            GetComponentInChildren<IInteractable>().Use();
        }
    }
}
