using UnityEngine;


public class TriggerTest : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Inside trigger: " + other.name);
    }
}