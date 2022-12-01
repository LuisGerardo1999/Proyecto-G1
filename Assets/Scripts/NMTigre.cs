using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMTigre : Mensajes
{
    [SerializeField] private GameObject pointer;
    public NavMeshAgent EnemyNaveMesh;
    public Transform TransformPointer;
    Animator animator;
    int isRunningHash;
    int isCloseHash;
    public Transform TransformPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("IsRunning");
        isCloseHash = Animator.StringToHash("IsClose");  
    }

    void Update()
    {

        bool isClose = animator.GetBool(isCloseHash);
        bool isRunning = animator.GetBool(isRunningHash);
        float dist = Vector3.Distance(transform.position, TransformPointer.position);

        if(dist <= 20)
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
            MensajesUI.fontSize = 80;
            MensajesUI.text = "El enemigo te esta atacando";
            Invoke("ResetearText", 5f);
        }
    }
}
