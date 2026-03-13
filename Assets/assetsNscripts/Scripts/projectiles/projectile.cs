using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public Vector3 direction;
    private Rigidbody rb;


    public void setDirection(Vector3 dir)
    {
        direction = dir.normalized;
        transform.forward = direction;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, lifetime);
        rb.linearVelocity = speed * direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.takeDamage(1);
        }
        Destroy(gameObject);

    }
}
