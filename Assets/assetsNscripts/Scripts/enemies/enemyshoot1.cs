using System.Threading;
using UnityEngine;

public class enemyshoot1 : MonoBehaviour
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
        timer = 1;
    }
}
