using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBombCharacter : MonoBehaviour
{
    public int hitCounter;
    public bool activateSparkle = false;
    private int randomNumber;
    [SerializeField] private GameObject[] reBornPoints;
    [SerializeField] private GameObject spariklingEffect;
    public Behaviour CharacterActor;


    private void Start() {
        reBornPoints = GameObject.FindGameObjectsWithTag("ReBornPoint");
    }
    private void Update() {
        if(hitCounter == 3)
        {
            hitCounter = 0;
            randomNumber = Random.Range(0, reBornPoints.Length);
            CharacterActor.enabled = false;
            this.gameObject.transform.position = reBornPoints[randomNumber].transform.position;
            CharacterActor.enabled = true;
            
        }
        if(activateSparkle == true)
        {
            spariklingEffect.SetActive(true);
        }
        else
        {
            spariklingEffect.SetActive(false);
        }
    }
    
    
}
