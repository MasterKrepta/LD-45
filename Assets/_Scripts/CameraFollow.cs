using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] Vector3 CameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        CameraOffset = transform.position - Target.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Target.position + CameraOffset;
    }
}
