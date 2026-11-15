using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody sphereRB;

    private float moveInput;
    private float turnInput;

    public float offRoadSpeed;
    public float normalSpeed;
    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    public GameObject leftPS;
    public GameObject rightPS;
    public bool isOffroad;

    private void Start()
    {
        forwardSpeed = normalSpeed;

        sphereRB.transform.parent = null;
    }
    private void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        if (isOffroad)
        {
            forwardSpeed = offRoadSpeed;
        }
        else if(!isOffroad)
        {
            forwardSpeed = normalSpeed;
        }
        moveInput *= moveInput > 0 ? forwardSpeed : reverseSpeed;

        if (turnInput != 0)
        {
            leftPS.SetActive(true);
            rightPS.SetActive(true);
        }
        else
        {
            leftPS.SetActive(false);
            rightPS.SetActive(false);
        }
/*        if (moveInput > 0)
        {
            moveInput *= forwardSpeed;
        }
        else
        {
            moveInput *= revSpeed;
        }*/

        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
/*    [Header ("Components")]
    private Rigidbody rb;

    [Header ("Speed & Position")]
    public Vector3 playerPosition;
    private Vector3 directionalInput;
    public float acceleration;
    public float accelerationTime;
    public float maxSpeed;
    public Vector3 velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        acceleration = maxSpeed / accelerationTime;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(velocity.x, rb.linearVelocity.y) * directionalInput;
    }
    void Update()
    {
        velocity += acceleration * directionalInput * Time.deltaTime; ;

        /* <--- Debug --->
        
        playerPosition = transform.position;
        playerPosition += new Vector3(velocity.x, velocity.y, 0f);
        transform.position = playerPosition;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }*/
