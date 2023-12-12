using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CherryBombLeaderboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private CherryBombPlacement placementTest;
    private bool reversePlacement = false;

    void Start()
    {
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update()
    {
        LeaderBoard();
    }

    void LeaderBoard()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);

            text.text = "Placement:\n";

            if (placementTest != null && placementTest.placement != null)
            {
                
                

                for (int i = 0; i < placementTest.placement.Length; i++)
                {
                    if (placementTest.placement[i] != null && placementTest.placement[i].name != null)
                    {
                        text.text += (i + 1) + ". " + placementTest.placement[i].name + "\n";
                    }
                }
            }
        }
        else
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
