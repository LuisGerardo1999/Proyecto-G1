using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRat : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    public Transform TransformPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        
        
    }

    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        

        float dist = Vector3.Distance(transform.position, TransformPlayer.position);

        if (dist <= 30)
        {
            animator.SetBool(isRunningHash, true);
        }

        if (dist > 30)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
