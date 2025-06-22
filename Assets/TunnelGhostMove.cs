using System;
using UnityEngine;

public class TunnelGhostMove : MonoBehaviour
{
    public float speed;
    private Vector3 position;
    private bool triggered = false;
    
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}
