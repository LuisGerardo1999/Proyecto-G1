using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventosPlayer_v1 : MonoBehaviour
{
    [SerializeField] private UnityEvent ColliderEnter;
    [SerializeField] private UnityEvent TriggerEnter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
             ColliderEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
    
        if (other.transform.tag == "Player")
        {
             TriggerEnter.Invoke();
        }
    }
}
