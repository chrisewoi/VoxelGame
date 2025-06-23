using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private static bool fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fire)
        {
            animator.SetTrigger("PickupAnim");
            fire = false;
        }
    }

    public static void FireTrigger()
    {
        fire = true;
    }
}
