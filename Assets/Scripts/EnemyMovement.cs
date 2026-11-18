using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyMovement : MonoBehaviour
{
    public int waypointIndex;
    public Transform[] waypointsList;

    private Vector3 targetPosition;

    public float moveSpeed;
    private void Start()
    {
        transform.position = waypointsList[0].position;
    }

    private void Update()
    {
        FollowPath();
        TurnHead();
    }
    private void FollowPath()
    {
        if (waypointIndex < waypointsList.Length)
        {
            if (waypointIndex + 1 >= waypointsList.Length)
            {
                targetPosition = waypointsList[0].position;
            }
            else
            {
                targetPosition = waypointsList[waypointIndex + 1].position;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            //Vector2 direction = (targetPosition - transform.position).normalized;
            //transform.Rotate(direction);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;

            Vector3 targetPosition = waypointsList[waypointIndex].position;
        }
    }
    public void TurnHead()
    {
        if (waypointIndex + 1 >= waypointsList.Length)
        {
            transform.LookAt(waypointsList[0]);

            print(waypointsList[0]);
        }
        else
        {
            transform.LookAt(waypointsList[waypointIndex + 1]);

            print(waypointsList[waypointIndex + 1]);
        }
    }
}
