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
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
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
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
    }

    private void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}
