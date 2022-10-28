using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NWRata : MonoBehaviour
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

        if(dist < 10)
        {
            EnemyNaveMesh.destination = pointer.transform.position;
        }
        if(dist > 15) 
        {
            EnemyNaveMesh.destination = EnemyNaveMesh.transform.position;
        }
    }

}
