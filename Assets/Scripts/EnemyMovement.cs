using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public int waypointIndex;
    public Transform[] waypointsList;

    public float moveSpeed;
    private void Start()
    {
        transform.position = waypointsList[0].position;
    }

    private void Update()
    {
        FollowPath();
    }
    private void FollowPath()
    {
        if (waypointIndex < waypointsList.Length)
        {
            Vector3 targetPosition = waypointsList[waypointIndex + 1].position;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
                print("reached");
            }
        }
        else
        {
            waypointIndex = 0;

            Vector3 targetPosition = waypointsList[waypointIndex].position;
        }
    }
}
