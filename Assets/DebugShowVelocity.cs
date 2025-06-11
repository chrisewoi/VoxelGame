using KinematicCharacterController;
using UnityEngine;

public class DebugShowVelocity : MonoBehaviour
{
    private KinematicCharacterMotor kinematicCharacterMotor;
    void Start()
    {
        kinematicCharacterMotor = GetComponent<KinematicCharacterMotor>();
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + kinematicCharacterMotor.BaseVelocity);
        //Debug.Log(kinematicCharacterMotor.BaseVelocity);
    }

    public Vector3 GetLookPoint()
    {
        Vector3 velocityOffset = Vector3.Scale(kinematicCharacterMotor.BaseVelocity, new Vector3(2f, 0.4f, 2f)); // THIS IS WHERE THE LOOK VELOCITY MULT IS <<<
        return transform.position + velocityOffset; 
    }

    public Vector3 GetVelocity()
    {
        return kinematicCharacterMotor.BaseVelocity;
    }
}
