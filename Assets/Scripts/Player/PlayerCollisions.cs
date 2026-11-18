using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public Rigidbody rb;
    public SphereCollider sc;
    public MeshRenderer meshRenderer;
    public PlayerManager playerManager;

    public Vector3 newPosition;

    public bool isOffroad;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        sc = GetComponent<SphereCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerManager.GetComponent<PlayerManager>().Dead();

            rb.isKinematic = true;

            meshRenderer.enabled = false;
            sc.enabled = false;

            print("recieved");
        }
    }

    private void Respawn()
    {
        transform.position = newPosition;
    }
}
