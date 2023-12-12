using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryOClockMapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private int cherryOClockCherries;
    [SerializeField] private CherryOClockPlacement placementTest;
    private void Start() {
        players = new GameObject[GameObject.FindGameObjectsWithTag("Character").Length];
    }
    

    
    private void Update()
    {
        if(placementTest.placementIndex == 0 )
        {
            players = placementTest.placement;
            Debug.Log("Harita bitti");
            
            
            
        }
        
    }
}
