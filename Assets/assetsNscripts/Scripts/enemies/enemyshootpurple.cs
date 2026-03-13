using System.Threading;
using UnityEngine;

public class enemyshootpurple : MonoBehaviour
{

    private float timer;
    private int counter = 0;

    public float firerate;

    [Header("initial setup")]
    public Transform spawnpoint;
    public GameObject bulletprefab;
    public GameObject bulletprefabpurple;
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
            if(counter==3){
                shootpurple();
                counter = 0;
            }
            else
            {
                shoot();
                counter++;
            }
        }

        
    }

    private void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, spawnpoint.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("world object holder").transform);
        bullet.GetComponent<projectile>().setDirection(spawnpoint.transform.forward);
        timer = 1;
    }

    private void shootpurple()
    {
        GameObject bullet = Instantiate(bulletprefabpurple, spawnpoint.transform.position, Quaternion.identity,GameObject.FindGameObjectWithTag("world object holder").transform);
        bullet.GetComponent<projectile>().setDirection(spawnpoint.transform.forward);
        timer = 1;
    }
}
