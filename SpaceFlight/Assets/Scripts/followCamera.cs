using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform target;
    public Transform rotTarget;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 offset = new Vector3(0,2,-10);
        transform.position = target.position + offset;
        transform.rotation = rotTarget.rotation;
    }
}
