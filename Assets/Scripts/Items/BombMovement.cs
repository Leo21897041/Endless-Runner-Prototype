using UnityEngine;

public class BombMovement : MonoBehaviour
{
    public float bulletSpeed = 10;
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.forward * bulletSpeed * Time.fixedDeltaTime;
    }
}
