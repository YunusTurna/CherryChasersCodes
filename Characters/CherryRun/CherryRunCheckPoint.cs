using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryRunCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentCheckPoint;
    [SerializeField] private GameObject[] checkPoints;

    public Behaviour CharacterActor;

    private void Start()
    {
        // Find all game objects with the "CheckPoint" tag
        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoint");
        
        // Initialize the current checkpoint to the first one
        currentCheckPoint = FindClosestCheckpoint();

        
    }

    private void Update()
    {
        if (Mathf.Abs(player.transform.position.x - FindClosestCheckpoint().transform.position.x) < 5f)
        {
            currentCheckPoint = FindClosestCheckpoint();
        }
        
        // Check if the player's Y position is below 2f
        if (player.transform.position.y < 3f)
        {
            CharacterActor.enabled = false;
            player.transform.position = currentCheckPoint.transform.position;
            CharacterActor.enabled = true;
            Debug.Log("Calisti");
        }
    }

    private GameObject FindClosestCheckpoint()
    {
        GameObject closestCheckpoint = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject checkpoint in checkPoints)
        {
            float distance = Mathf.Abs(player.transform.position.x - checkpoint.transform.position.x);
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCheckpoint = checkpoint;
            }
        }

        return closestCheckpoint;
    }
}
