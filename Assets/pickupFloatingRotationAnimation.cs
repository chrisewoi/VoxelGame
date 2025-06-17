using UnityEngine;

public class pickupFloatingRotationAnimation : MonoBehaviour
{
    private float originalY;
    [SerializeField] private float distanceMin = 5f;
    [SerializeField] private float distanceMax = 20f;
    private float randomFloat;
    [SerializeField] private float timeMin = 5f;
    [SerializeField] private float timeMax = 20f;
    private float randomTime;
    [SerializeField] private float rotationMin = 5f;
    [SerializeField] private float rotationMax = 20f;
    private float randomRotation;



    void Start()
    {
        this.originalY = this.transform.position.y;
        randomFloat = Random.Range(distanceMin, distanceMax);
        randomTime = Random.Range(timeMin, timeMax);
        randomRotation = Random.Range(rotationMin, rotationMax);
    }
    void Update()
    {
        //We Rotate the Object here
        gameObject.transform.Rotate(new Vector3(0f, randomRotation, 0f) * Time.deltaTime);
        //We Move the Object here - The distance and time is random for each object
        gameObject.transform.position = new Vector3(transform.position.x,
            originalY + (Mathf.Sin(randomTime + Time.time) * randomFloat), transform.position.z);

    }
}

