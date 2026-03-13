using UnityEngine;

public class basicEnemyHealth : MonoBehaviour, IDamageable
{

    public float hitpoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void takeDamage(float damage)
    {
        hitpoints-=damage;
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
