using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NWRata : Mensajes
{
    [SerializeField] private GameObject pointer;
    public NavMeshAgent EnemyNaveMesh;
    public Transform TransformPointer;
    Animator animator;
    public Transform TransformPlayer;

    void Start()
    {
        animator = GetComponent<Animator>();
 
    }

    void Update()
    {


        float dist = Vector3.Distance(transform.position, TransformPointer.position);

        if(dist <= 20)
        {
            EnemyNaveMesh.destination = pointer.transform.position;

        }
        if(dist <= 5) 
        {
            EnemyNaveMesh.destination = EnemyNaveMesh.transform.position;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            MensajesUI.text = "La Rata Te muerde!!!!";
            Invoke("ResetearText", 5f);
        }
    }
}
