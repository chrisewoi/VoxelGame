using UnityEngine;

public class LightFire : MonoBehaviour
{
    public bool lit;
    public GameObject player, lightswitch;
    public float activateDistance;
    public float distance;
    public float lightTime;

    public Animator animator;
    
    public GameObject gate;
    private Transform gateStartPos;
    public Transform gateEndPos;
    private bool hasGate;
    private bool activateGate;
    private float gateTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lit = false;
        lightswitch.SetActive(false);
        if (gate != null)
        {
            hasGate = true;
            gateStartPos = gate.transform;
        }

        gateTimer = -0.05f;
    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, lightswitch.transform.position);
        if (!lit && activateDistance > distance)
        {
            lit = true;
            //animator.SetTrigger("PickupAnim");
            PlayerAnimationController.FireTrigger();
        }

        if(lit != lightswitch.activeInHierarchy)
        {
            lightTime -= Time.deltaTime;
            if (lightTime < 0f)
            {
                lightswitch.SetActive(lit);
                if (hasGate) activateGate = true;
            }
        }

        if (activateGate)
        {
            gate.transform.position = new Vector3(gate.transform.position.x,
                gate.transform.position.y,
                Mathf.Lerp(gateStartPos.position.z, gateEndPos.position.z, gateTimer));
            gateTimer += Time.deltaTime /30f;
        }
    }
}

