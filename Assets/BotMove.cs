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
    public CameraDistancePOI cameraDistancePOI;
    public float activateDistance;

    private float distance;
    private Vector3 v;

    public Transform hidePos;

    public float hideMult;
    private float hideMultCurrent;
    public Transform companion;
    private float companionMult;
    private Vector3 scaleOrig;

    private float glowMult;
    
    void Start()
    {
        scaleOrig = companion.localScale;
        hideMultCurrent = 1f;
    }

    void Update()
    {
        AccuracyOffset();
        timer += Time.deltaTime;
        
        distance = Vector3.Distance(transform.position, destination);
        
        if(activateDistance > cameraDistancePOI.GetPOIDistance()) //if near POI, put away bot
        {
            SetDestination(hidePos.position);
            hideMultCurrent += hideMult * Time.deltaTime;
            if (distance < 1f)
            {
                hideMultCurrent = 1000f;
                companion.localScale = Vector3.one;
                glowMult -= Time.deltaTime;
            }
        }
        else
        {
            SetDestination(offsetCurrent.position);
            hideMultCurrent = 1f;
            companion.localScale = scaleOrig;
            glowMult += Time.deltaTime;
        }

        glowMult = Mathf.Clamp01(glowMult);
        print(glowMult);
        
        
        if (distance > 1f)
        {
            // Move towards destination
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref v, speed / hideMultCurrent);
        }
    }

    public void SetDestination(Vector3 destination)
    {
        destination.y += GetVelocityMagnitude() * heightBySpeed / hideMultCurrent;
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

    private float GetVelocityMagnitude()
    {
        return kinematicCharacterMotor.Velocity.magnitude;
    }

    public float GetGlowMult()
    {
        return glowMult;
    }
}
