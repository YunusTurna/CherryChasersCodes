using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryRunFinish : MonoBehaviour
{
    public GameObject[] placement;
    
    public int placementIndex = 0;
    private void Start() {
        placement = GameObject.FindGameObjectsWithTag("Character");

    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Character")
        {
          placement[placementIndex] = other.gameObject;
          placementIndex++;
          other.gameObject.SetActive(false);
        }
    }
}
