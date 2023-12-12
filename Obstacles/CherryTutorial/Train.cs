using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField] private Transform patrolpoint1 , patrolpoint2 , currentDestination;
    [SerializeField] private float speed;

    void Start()
    {
        currentDestination = patrolpoint2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolpoint1.position)
        {
            currentDestination = patrolpoint2;
        }
        else if (transform.position == patrolpoint2.position)
        {
           transform.position = patrolpoint1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentDestination.position, speed * Time.deltaTime);
    }
}
