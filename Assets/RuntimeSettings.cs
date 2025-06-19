using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RuntimeSettings : MonoBehaviour
{
    [Header("DESTROYS ALL LIGHT OBJECTS\nIN THIS HIERARCHY ON RUNTIME!")]
    
    [TextArea]
    public string Notes = "Put lighting in this hierarchy for use in the editor. It will be disabled on runtime.\nhttps://www.freepik.com/free-photo/abstract-background-rock-texture_14622174.htm Image by freepik";
    
    private Light[] _lights;

    public int frameRate;

    void Start()
    {
        RenderSettings.fog = true;
        _lights = GetComponentsInChildren<Light>();
        foreach(Light light in _lights) Destroy(light.gameObject);
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
