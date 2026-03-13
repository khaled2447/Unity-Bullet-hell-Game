using UnityEngine;

public class PlayerHealth : MonoBehaviour , IDamageable
{

    public float hitpoints;
    [SerializeField] private GameObject hitpoint1;
    [SerializeField] private GameObject hitpoint2;
    [SerializeField] private GameObject damageEffect;

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
        if (hitpoints == 2)
        {
            hitpoint1.SetActive(false);
        }else if (hitpoints == 1)
        {
            hitpoint2.SetActive(false);
        }
        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
