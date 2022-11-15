using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaveMesh_V2 : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    public NavMeshAgent EnemyNaveMesh;
    public Transform TransformPointer;
    public Animator ControllerTigre;

    void Start()
    {
        
    }

   
    void Update()
    {
        float dist = Vector3.Distance (transform.position, TransformPointer.position);

        if(dist < 20)
        {
            EnemyNaveMesh.destination = pointer.transform.position;
            ControllerTigre.SetBool("IsRunning",true);
             Debug.Log(dist);
        }

        else
        {
            ControllerTigre.SetBool("IsRunning",false);
        }

        if(dist <= 5)
        {
           ControllerTigre.SetBool("IsClose",true);

        }
        else
        {
            ControllerTigre.SetBool("IsClose",false);
        }
       

       
    }
}
