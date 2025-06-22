using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TunnelGhostMove : MonoBehaviour
{
    public float speed;
    private Vector3 position;
    private bool triggered = false;

    public Volume volume;
    private float volumeWeight;
    private float startTime;
    public float easeTime;
    public AnimationCurve anim;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            position.z += speed * Time.deltaTime;
            gameObject.transform.position = position;
            volumeWeight = anim.Evaluate((Time.time - startTime)* easeTime);
            //volumeWeight = AnimationCurve.EaseInOut(startTime, 0f, startTime + easeTime, 1f).Evaluate(Time.time);
            volume.weight = volumeWeight;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
            startTime = Time.time;
        }
    }
}
