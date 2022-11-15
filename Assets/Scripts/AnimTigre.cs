using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTigre : MonoBehaviour
{
     Animator animator;
    int isWalkingHash;
    int isCloseHash;
    int isRunningHash;
    public Transform TransformPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isCloseHash = Animator.StringToHash("IsClose");
        isRunningHash = Animator.StringToHash("IsRunning");
        
    }

    void Update()
    {
        bool isClose = animator.GetBool(isCloseHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        float dist = Vector3.Distance(transform.position, TransformPlayer.position);

        if (dist <= 50)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (dist > 50)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (dist <= 30)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (dist > 30)
        {
            animator.SetBool(isRunningHash, false);
        }
                if (dist < 5)
        {
            animator.SetBool(isCloseHash, true);
        }

        if (dist > 5)
        {
            animator.SetBool(isCloseHash, false);
        }
    }
}
