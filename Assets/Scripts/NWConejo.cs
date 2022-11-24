using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NWConejo : Mensajes
{
    [SerializeField] private GameObject pointer;
    public NavMeshAgent EnemyNaveMesh;
    public Transform TransformPointer;
    Animator animator;
    int isRunningHash;
    int isCloseHash;
    int isAlertHash;
    public Transform TransformPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("IsRunning");
        isCloseHash = Animator.StringToHash("IsClose");  
        isAlertHash = Animator.StringToHash("IsAlert");
    }

    void Update()
    {

        bool isClose = animator.GetBool(isCloseHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isAlert = animator.GetBool(isAlertHash);
        float dist = Vector3.Distance(transform.position, TransformPointer.position);


        if(dist <= 20) 
        {
            EnemyNaveMesh.destination = EnemyNaveMesh.transform.position;
            animator.SetBool(isAlertHash, true);
        }

        if(dist <= 15)
        {
            EnemyNaveMesh.destination = pointer.transform.position;
            animator.SetBool(isRunningHash, true);
        }

        if(dist <= 5) 
        {
            EnemyNaveMesh.destination = EnemyNaveMesh.transform.position;
            animator.SetBool(isCloseHash, true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            MensajesUI.text = "Corre de los conejos!";
            Invoke("ResetearText", 5f);
        }
    }
}