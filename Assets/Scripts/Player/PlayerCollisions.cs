using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Vector3 newPosition;

    public bool isOffroad;
    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Offroad"))
        {
            isOffroad = true;

            Respawn();
        }
        if (collision.gameObject.CompareTag("Track"))
        {
            isOffroad = false;

            newPosition = transform.position;
        }
    }

    private void Respawn()
    {
        transform.position = newPosition;
    }
}
