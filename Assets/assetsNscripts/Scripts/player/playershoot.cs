using Unity.Mathematics; 
using UnityEngine; 
using UnityEngine.InputSystem; 
 
public class playershoot : MonoBehaviour 
{ 
    private float timer; 
    private bool isShooting; 
 
    public float firerate; 

    [Header("Initial Setup")] 
    public Transform spawnpoint; 
    public GameObject bulletprefab;

    private InputAction shootAction;
 
    void Awake()
    {
        // Grab the action directly from the PlayerInput component
        shootAction = GetComponent<PlayerInput>().actions["Shoot"];

        shootAction.started += _ => isShooting = true;    // finger down
        shootAction.canceled += _ => isShooting = false;  // finger up
    }

    void OnDestroy()
    {
        // Always unsubscribe to avoid ghost callbacks
        shootAction.started -= _ => isShooting = true;
        shootAction.canceled -= _ => isShooting = false;
    }
 
    void Update() 
    { 
        if (timer > 0) 
        { 
            timer -= Time.deltaTime * firerate; 
        } 

        if (isShooting && timer <= 0) 
        { 
            shoot(); 
        } 
    } 
     
    void shoot() 
    { 
        GameObject bullet = Instantiate(
            bulletprefab, 
            spawnpoint.transform.position, 
            Quaternion.identity,
            GameObject.FindGameObjectWithTag("world object holder").transform
        ); 

        bullet.GetComponent<projectile>().setDirection(spawnpoint.transform.forward); 
        timer = 1; 
    } 
}