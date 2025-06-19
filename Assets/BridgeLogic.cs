using System;
using UnityEngine;

public class BridgeLogic : MonoBehaviour
{
    private BoxCollider _boxCollider;

    public bool boxInPlace;

    public GameObject secretBridge;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        boxInPlace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxInPlace && !secretBridge.activeInHierarchy)
        {
            secretBridge.SetActive(true);
        }

        if (!boxInPlace && secretBridge.activeInHierarchy)
        {
            secretBridge.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            boxInPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            boxInPlace = false;
        }    
    }
}
