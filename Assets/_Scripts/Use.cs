using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    [SerializeField] Transform Hand;
    

    // Update is called once per frame
    void Update()
    {
        if (Hand.childCount == 1 && Input.GetKeyDown(KeyCode.T)) {
            GetComponentInChildren<IInteractable>().Use();
        }
    }
}
