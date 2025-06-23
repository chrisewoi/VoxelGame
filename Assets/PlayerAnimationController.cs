using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private static bool fire;
    private static bool moving;
    private static readonly int Move = Animator.StringToHash("Move");
    private static readonly int PickupAnim = Animator.StringToHash("PickupAnim");
    private static readonly int Jump = Animator.StringToHash("Jump");


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
            animator.SetTrigger(PickupAnim);
            fire = false;
        }
        
        animator.SetBool(Move, moving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger(Jump);
        }
    }

    public static void FireTrigger()
    {
        fire = true;
    }

    public static void Moving(bool isMoving)
    {
        moving = isMoving;
    }
}
