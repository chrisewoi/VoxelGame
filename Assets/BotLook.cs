using UnityEngine;
using UnityEngine.Serialization;

public class BotLook : MonoBehaviour
{
    public Vector3 destinationPoint;
    public float destinationRadius;
    [FormerlySerializedAs("accuracy")] public float inaccuracy;
    public float lightIOSpeed;
    public float updateRateMin;
    public float updateRateMax;
    public float smoothTime;
    private float updateRateCurrent;
    private float timer;
    private Vector3 v;

    public DebugShowVelocity destination;
    private Vector3 currentDestination;
    private Vector3 currentRandomOffset;

    public new Light light;
    public Light glowLight;
    private float glowLightIntensityDefault;
    private float lightIntensityDefault;
    private float lightIntensityMult;
    private float lightRandomOffsetMult;

    public CameraDistancePOI cameraDistancePOI;
    public float activateDistance;

    public Transform lineAnchor;
    public float spinSpeed;
    private float currentSpin;
    public LineRenderer line;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //light = GetComponent<Light>();
        lightIntensityDefault = light.intensity;
        updateRateCurrent = Random.Range(updateRateMin, updateRateMax);

        lightRandomOffsetMult = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        destinationPoint = Vector3.SmoothDamp(destinationPoint, currentDestination, ref v, smoothTime / lightRandomOffsetMult);
        
        transform.LookAt(destinationPoint);


        if(cameraDistancePOI.GetPOIDistance() > activateDistance) //if away from POI, turn on light
        {
            lightIntensityMult += Time.deltaTime;
        }
        else //if stopped, turn off light
        {
            lightIntensityMult -= Time.deltaTime * lightIOSpeed;
        }

        if (destination.GetVelocity().magnitude < 10f)
        {
            lightIntensityMult -= Time.deltaTime * lightIOSpeed;
        }

        lightIntensityMult = Mathf.Clamp01(lightIntensityMult);

        
        if (lightIntensityMult is > 0.01f and < 0.99f)
        {
            line.widthMultiplier = 0.3f;
            Vector3 lineAngle = new Vector3(0f, 0f, lightIntensityMult * spinSpeed);
            lineAnchor.localEulerAngles = lineAngle;
        }
        else
        {
            line.widthMultiplier = 0f;
        }
        
        

        if (timer > updateRateCurrent)
        {
            updateRateCurrent = Random.Range(updateRateMin, updateRateMax);
            timer = 0f;
            light.intensity = lightIntensityDefault * lightIntensityMult;
            glowLight.intensity = glowLightIntensityDefault * lightIntensityMult;

            if(Random.value < 0.9f) currentDestination = destination.GetLookPoint() + currentRandomOffset; // 10% chance the light "forgets" to update


            
            if(Random.value < 0.2)  {
                currentRandomOffset = (Random.insideUnitSphere * inaccuracy); // THIS IS WHERE LIGHT RANDOM RATE IS
                lightRandomOffsetMult = Random.Range(2f,5f);
            }
        }
        //Debug.Log("Vel Mag: " + destination.GetVelocity().magnitude);

        timer += Time.deltaTime;
        lightRandomOffsetMult -= 8f * Time.deltaTime;
        lightRandomOffsetMult = Mathf.Clamp(lightRandomOffsetMult, 1f, 4f);
    }
}
