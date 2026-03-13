using UnityEngine;

public class EnemyhealthDmgnDeathEffects : MonoBehaviour , IDamageable
{

    public float hitpoints;
    public GameObject damageEffect;
    public GameObject deathEffect;

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
        Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);

        if (hitpoints <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
