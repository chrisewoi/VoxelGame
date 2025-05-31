using KinematicCharacterController.Examples;
using UnityEngine;

public class CameraDistancePOI : MonoBehaviour
{
    public GameObject player;
    public Transform[] poi;

    public float distanceMin, distanceMax;
    public float cameraMin, cameraMax, cameraCurrent;
    public float smoothTime;
    public float cameraCurrentSmooth;

    public float currentMinDistance;
    public float cameraCurrentIncrement;
    

    private ExampleCharacterCamera ExampleCharacterCamera;
    private float v;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ExampleCharacterCamera = GetComponent<ExampleCharacterCamera>();
        currentMinDistance = distanceMax;
    }

    // Update is called once per frame
    void Update()
    {
        currentMinDistance = distanceMax;
        foreach (var poi in poi)
        {
            float dist = Vector3.Distance(poi.transform.position, player.transform.position);
            if (dist < currentMinDistance) currentMinDistance = dist;
        }

        cameraCurrent = Mathf.Lerp(cameraMin, cameraMax, Mathf.InverseLerp(distanceMin, distanceMax, currentMinDistance));
        print(cameraCurrent);
        //ExampleCharacterCamera.DefaultDistance = Mathf.Round(cameraCurrent/cameraCurrentIncrement)*cameraCurrentIncrement;
        //ExampleCharacterCamera.MaxDistance = Mathf.Round(cameraCurrent / cameraCurrentIncrement) * cameraCurrentIncrement;
        ExampleCharacterCamera.MaxDistance = Mathf.SmoothDamp(cameraCurrentSmooth, cameraCurrent, ref v, smoothTime);
    }
}
