using UnityEngine;

public class LightFire : MonoBehaviour
{
    public bool lit;
    public GameObject player, lightswitch;
    public float activateDistance;
    public float distance;
    public float lightTime;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lit = false;
    }


    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, lightswitch.transform.position);
        if (!lit && activateDistance > distance)
        {
            lit = true;
            animator.SetTrigger("PickupAnim");
        }

        if(lit != lightswitch.activeInHierarchy)
        {
            lightswitch.SetActive(lit);
        }
    }
}

