using System.Threading;
using UnityEngine;

public class enemyshootTriple : MonoBehaviour
{

    private float timer;

    public float firerate;

    [Header("initial setup")]
    public Transform spawnpoint;
    public GameObject bulletprefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime*firerate;
        }
        if (timer<=0)
        {
            shoot();
        }
        
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, spawnpoint.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("world object holder").transform);
        bullet.GetComponent<projectile>().setDirection(spawnpoint.transform.forward);
        GameObject bullet2 = Instantiate(bulletprefab, spawnpoint.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("world object holder").transform);
        bullet2.GetComponent<projectile>().setDirection(Quaternion.Euler(0, 30f, 0)*spawnpoint.transform.forward);
        GameObject bullet3 = Instantiate(bulletprefab, spawnpoint.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("world object holder").transform);
        bullet3.GetComponent<projectile>().setDirection(Quaternion.Euler(0, -30f, 0)*spawnpoint.transform.forward);
        timer = 1;
    }
}
