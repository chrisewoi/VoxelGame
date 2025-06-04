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
        return transform.position + kinematicCharacterMotor.BaseVelocity;
    }

    public Vector3 GetVelocity()
    {
        return kinematicCharacterMotor.BaseVelocity;
    }
}
