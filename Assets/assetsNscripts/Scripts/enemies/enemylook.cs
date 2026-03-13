using Unity.Mathematics;
using UnityEngine;

public class enemylook : MonoBehaviour
{
    private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pointer = (player.position - transform.position).normalized;
            Quaternion target = Quaternion.LookRotation(pointer);
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, target ,180f *Time.deltaTime);
        }
    }
}
