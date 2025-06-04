using UnityEngine;

public class BotLook : MonoBehaviour
{
    public Vector3 destinationPoint;
    public float destinationRadius;
    public float lightIOSpeed;
    public float updateRateMin;
    public float updateRateMax;
    private float timer;

    public DebugShowVelocity destination;

    private Light light;
    private float lightIntensityDefault;
    private float lightIntensityMult;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
        lightIntensityDefault = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        destinationPoint = destination.GetLookPoint();
        
        transform.LookAt(destinationPoint);

        if (destination.GetVelocity().magnitude < 10f)
        {
            lightIntensityMult -= Time.deltaTime * lightIOSpeed;
        }
        else
        {
            lightIntensityMult += Time.deltaTime;
        }

        lightIntensityMult = Mathf.Clamp01(lightIntensityMult);

        //if(timer > )
        light.intensity = lightIntensityDefault * lightIntensityMult;
        //Debug.Log("Vel Mag: " + destination.GetVelocity().magnitude);

        timer += Time.deltaTime;
    }
}
