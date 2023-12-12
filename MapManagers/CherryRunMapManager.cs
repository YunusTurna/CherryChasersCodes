using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryRunMapManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private int cherryRunCherries;
    [SerializeField] private CherryRunFinish cherryRunFinish;
    
    int  deneme;

    private int i;

    private void Start() {
        
        players = GameObject.FindGameObjectsWithTag("Character");
        deneme =  GameObject.FindGameObjectsWithTag("Character").Length;
        
        
    }
    private void Update()
    {
        if(cherryRunFinish.placementIndex == deneme )
        {
            for (int i = 0; i < cherryRunFinish.placement.Length; i++)
            {
                players[i] = cherryRunFinish.placement[i];
            }
            
            
            
        }
        
    }
}
