using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBombPlacement : MonoBehaviour
{
    public GameObject[] placement;
    public int placementIndex = 0;



    private void Start()
    {
        placement = new GameObject[GameObject.FindGameObjectsWithTag("Character").Length];
        placementIndex = GameObject.FindGameObjectsWithTag("Character").Length;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Collider[] colliders = other.gameObject.GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
            if (placementIndex > -1)
            {
                placement[placementIndex - 1] = other.gameObject;
                placementIndex--;
            }
            other.gameObject.tag = "CharacterDead";
        }

    }
}
