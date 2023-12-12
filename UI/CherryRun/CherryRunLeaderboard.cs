using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CherryRunLeaderBoard : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CherryRunFinish cherryRunFinish;
    
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        
        
    }

    
    void Update()
    {
        LeaderBoard();
    }

    void LeaderBoard()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            text.text = "Placement:\n";

            for (int i = 0; i < cherryRunFinish.placement.Length; i++)
            {
                text.text += (i + 1) + ". " + cherryRunFinish.placement[i].name + "\n";
            }
            
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void EndGameCherries(){}
}

