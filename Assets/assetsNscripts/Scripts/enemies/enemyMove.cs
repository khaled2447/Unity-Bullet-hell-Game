using UnityEngine;

public class enemyMove : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            rb.linearVelocity = speed*gameObject.transform.forward;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
