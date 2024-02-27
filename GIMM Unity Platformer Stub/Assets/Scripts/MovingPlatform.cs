using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MovingPlatformController : MonoBehaviour
    {
        public Transform[] waypoints; // An array of waypoints (your platform's path)
        public float speed = 3.0f; // Speed of platform movement
        private int currentWaypointIndex = 0;

        void Update()
        {
            // Move the platform towards the current waypoint
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // If the platform has reached the current waypoint, switch to the next waypoint
            if (transform.position == targetPosition)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }

