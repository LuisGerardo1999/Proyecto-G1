using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlState : MonoBehaviour
{

    Animator animator;
    int isWalkingHash;
    int isrunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isrunningHash = Animator.StringToHash("IsRunning");

    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isrunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetButton("Horizontal");
        bool forwardPressedL = Input.GetButton("Vertical");
        bool walkpressed = forwardPressed || forwardPressedL;
        bool RunPressed = Input.GetKey("left shift");

        if (!isWalking && walkpressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !walkpressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (walkpressed && RunPressed))
        {
            animator.SetBool(isrunningHash, true);
        }

        if (isRunning && (!walkpressed || !RunPressed))
        {
            animator.SetBool(isrunningHash, false);
        }
    }

}
