using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    Vector3 velocity;
    public float acceleration = 50f;
    public float maxSpeed = 20f;
    public float friction = 16f;
    private Vector2 moveInput;

    private Rigidbody rb;
    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(moveInput.x,0,moveInput.y).normalized;

    }
    void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;

        velocity += direction * acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (direction == Vector3.zero)
        {
            velocity = Vector3.Lerp(velocity,Vector3.zero,friction*Time.deltaTime);
        }

        rb.linearVelocity = velocity;
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
