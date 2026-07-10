using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private Path path;
    [SerializeField] private float speed = 1;
    [SerializeField] private int nextWaypointIndex;
    [SerializeField] private float reachedWaypointClearance = 0.25f;

    void Awake()
    {
        path = FindAnyObjectByType<Path>();
    }

    void Start()
    {
        transform.position = path.waypoints[0].position;
        nextWaypointIndex = 1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance) {
            nextWaypointIndex++;

            if (nextWaypointIndex >= path.waypoints.Length) {
                nextWaypointIndex = 0;
            }
        }
    }
}
