using System;
using KinematicCharacterController;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BotMove : MonoBehaviour
{
    public float accuracy;
    public float speedMax;
    public float speed;
    public float updateRateMin;
    public float updateRateMax;

    public Vector3 destination; 
    public Transform offsetDefault;
    public Transform offsetCurrent;
    public float heightBySpeed;

    public Transform player;
    public KinematicCharacterMotor kinematicCharacterMotor;

    private float distance;
    private Vector3 v;

    public Transform set;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        AccuracyOffset();
        timer += Time.deltaTime;
        SetDestination(offsetCurrent.position);
        
        distance = Vector3.Distance(transform.position, destination);

        if (distance > 1f)
        {
            // Move towards destination
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref v, speed );
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        transform.forward = player.forward;
    }

    private float timer;
    public void AccuracyOffset()
    {
        if (timer > Mathf.Lerp(updateRateMin, updateRateMax, Random.value))
        {
            offsetCurrent.position = offsetDefault.position + Random.insideUnitSphere * accuracy;
            timer = 0;
        }
    }
}
