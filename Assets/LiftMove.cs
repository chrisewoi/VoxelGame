using System;
using UnityEngine;

public class LiftMove : MonoBehaviour
{
    public float moveTime;
    public float delay;

    private float startY;
    public float endY;
    private float timer;
    private Vector3 currentPos;

    private bool riding;
    
    void Start()
    {
        timer = 0f;
        currentPos = transform.position;
        startY = currentPos.y;
        riding = false;
    }

    void Update()
    {
            currentPos.y = Mathf.Lerp(startY, startY + endY, Mathf.InverseLerp(delay, delay + moveTime, timer));
        


        if (riding)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        timer = Mathf.Clamp(timer, 0f, moveTime + (delay * 2f));

        print("lerp: " + (Mathf.Lerp(delay, delay + moveTime, timer)-delay)/moveTime);
        print("iLerp: " + Mathf.Lerp(startY, startY + endY, (Mathf.Lerp(delay, delay + moveTime, timer)-delay)/moveTime));
        
        transform.position = currentPos;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //riding = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            riding = true;
            if (timer >= moveTime + (delay * 2f))
            {
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            riding = false;
        }
    }
}
