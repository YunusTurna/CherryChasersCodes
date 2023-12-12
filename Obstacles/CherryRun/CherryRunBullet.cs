using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryRunBullet : MonoBehaviour
{
    Rigidbody rb;
    
    public float pushPower = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Character")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = other.gameObject.GetComponent<Rigidbody>().velocity + new Vector3(10,10,10);
            
        }
    }
}
