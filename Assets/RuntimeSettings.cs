using UnityEditor;
using UnityEngine;

public class RuntimeSettings : MonoBehaviour
{
    [Header("DESTROYS ALL LIGHT OBJECTS\nIN THIS HIERARCHY ON RUNTIME!")]
    
    [TextArea]
    public string Notes = "Put lighting in this hierarchy for use in the editor. It will be disabled on runtime.";
    
    private Light[] _lights;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RenderSettings.fog = true;
        _lights = GetComponentsInChildren<Light>();
        foreach(Light light in _lights) Destroy(light.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
