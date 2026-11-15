using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovement playerMovement;


    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Offroad"))
        {
            playerMovement.isOffroad = true;
        }
        if (collision.gameObject.CompareTag("Track"))
        {
            playerMovement.isOffroad = false;
        }
    }
}
