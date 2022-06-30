using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public Transform[] waypoints;
    public int enemySpeed;

    private int waypointIndex;
    private float dist;
    public float maxDist = 1.3f;

    void Start()
    {
        waypointIndex = 0;
        //make the enemy look at where they are going
        transform.LookAt(waypoints[waypointIndex].position);
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if(dist < maxDist)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    private void Patrol()
    {
        //move towards the waypoint
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    private void IncreaseIndex()
    {
        //going to the next waypoint in the array
        waypointIndex++;
        //when having reached the last waypoint reset it to the first one to create a loop
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        //make the enemy face the next waypoint when switching
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
