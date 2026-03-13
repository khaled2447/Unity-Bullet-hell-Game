using UnityEngine;

public class ComponentNameExample : MonoBehaviour
{
    void Start()
    {
        // Get all components on this GameObject
        Component[] allComponents = GetComponents<Component>();

        Debug.Log("Components on this GameObject:");
        foreach (Component component in allComponents)
        {
            // Use GetType() to get the actual class/type name
            Debug.Log(component.GetType().ToString());
        }
    }
}
