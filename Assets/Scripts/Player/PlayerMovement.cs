using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody sphereRB;
    public float moveInput;
    public float turnInput;
    public float currentSpeed;
    public float normalSpeed;
    public float forwardSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    public GameObject leftPS;
    public GameObject rightPS;
    public bool isDriving;    

    private void Start()
    {
        forwardSpeed = normalSpeed;

        sphereRB.transform.parent = null;
    }
    private void Update()
    {
        /*        moveInput = Input.GetAxisRaw("Vertical");
                turnInput = Input.GetAxisRaw("Horizontal");*/

        currentSpeed = moveInput * (moveInput > 0 ? forwardSpeed : reverseSpeed);

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

        /*        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
                    transform.Rotate(0, newRotation, 0, Space.World);*/
        if (Mathf.Abs(moveInput) > 0.01f)
        {
            float direction = moveInput > 0 ? 1f : -1f;
            float newRotation = turnInput * turnSpeed * Time.deltaTime * direction;
            transform.Rotate(0, newRotation, 0, Space.World);
        }
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
    }

    public void OnDrive(InputAction.CallbackContext context)
    {
        print("Driving");
        if (context.performed == true)
        {
            isDriving = true;

            moveInput = 1f;
        }
        else if (context.canceled == true)
        {
            isDriving = false;

            moveInput = 0;
        }
    }
    public void OnReverse(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            print("Reversing");
            isDriving = true;

            moveInput = -1f;
        }
        else if (context.canceled == true)
        {
            isDriving = false;

            moveInput = 0;
        }
    }
    public void OnTurn(InputAction.CallbackContext context)
    {
        turnInput = context.ReadValue<float>();
        
        if (turnInput != 0f)
        {
            print("Turning");
        }
    }
    public void OnItems(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GetComponent<PlayerItemSpawner>().PlaceItem();
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GetComponent<PlayerItemSpawner>().Shoot();
        }
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
