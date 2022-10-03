using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventosPlayer_v1 : MonoBehaviour
{
    [SerializeField] private UnityEvent ColliderEnter;
    [SerializeField] private UnityEvent ColliderExit;
    [SerializeField] private UnityEvent TriggerEnter;
    [SerializeField] private UnityEvent TriggerExit;
    [SerializeField] private UnityEvent TriggerStay;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
             ColliderEnter.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            ColliderEnter.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            TriggerEnter.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            TriggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    
        if (other.transform.tag == "Player")
        {
             TriggerEnter.Invoke();
        }
    }
}
