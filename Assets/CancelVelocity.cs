using UnityEngine;

public class CancelVelocity : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }
}
