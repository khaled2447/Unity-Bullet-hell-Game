using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class playerLook : MonoBehaviour
{
    Camera cam;
    private PlayerInput playerInput;
    private bool isGamepad = false;
    private Vector3 lookInput;
    Plane groundPlane;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }   // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        groundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void OnControlsChanged()
    {
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
        }
        isGamepad = playerInput.currentControlScheme == "Gamepad";
        if (isGamepad)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamepad)
        {
        Vector3 direction = new Vector3(lookInput.x, 0f, lookInput.z);
        if (direction.sqrMagnitude > 0.01f)
        {
             Quaternion targetRotation = Quaternion.LookRotation(lookInput);
            float superFastSmooth = 30f;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, superFastSmooth * Time.deltaTime);
        }
        }
        else
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            groundPlane.Raycast(ray, out float distance);
            Vector3 location = ray.GetPoint(distance);
            Vector3 direction = location - transform.position; direction.y = 0f; 
            if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction); 
        }

    }

    public void OnLook(InputValue value)
    {
        Vector2 lookInput2 = value.Get<Vector2>();
        lookInput = new Vector3(lookInput2.x,0,lookInput2.y);
    }
}
