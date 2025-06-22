using UnityEngine;

public class EnableLightOnStart : MonoBehaviour
{
    private Light light;
    
    void Awake()
    {
        light = GetComponent<Light>();
        light.enabled = true;
    }

}
