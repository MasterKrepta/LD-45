using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomColor : MonoBehaviour
{
    [SerializeField] Material[] Colors;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = Colors[Random.Range(0, Colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
