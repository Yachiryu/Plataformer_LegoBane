using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public GameObject[] waypoints;
    public int waypointIndex = 0;

    public float platformSpeed = 2;

    public float minDistancePoint; 

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform() 
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position) < minDistancePoint )
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, platformSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
