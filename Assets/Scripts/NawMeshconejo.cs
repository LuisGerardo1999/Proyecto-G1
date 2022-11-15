using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NawMeshconejo : Mensajes
{
    [SerializeField] private GameObject pointer;
    public NavMeshAgent EnemyNaveMesh;
    public Transform TransformPointer;

    void Start()
    {
 
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, TransformPointer.position);

        if(dist < 20)
        {
            EnemyNaveMesh.destination = pointer.transform.position;
        }
        if(dist > 21) 
        {
            EnemyNaveMesh.destination = EnemyNaveMesh.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            MensajesUI.text = "Has sido infectado";
            Invoke("ResetearText", 5f);
        }
    }
}
