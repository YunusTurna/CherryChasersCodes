using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHoleCover : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    

    
    void Update()
    {
        transform.Rotate(new Vector3(1,0,0) * rotationSpeed * Time.deltaTime, Space.Self);
        
    }
}
