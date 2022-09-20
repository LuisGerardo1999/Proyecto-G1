using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjTocar : MonoBehaviour
{
    [SerializeField] private UnityEvent ColliderEnter;
    [SerializeField] private UnityEvent TriggerStay;
    [SerializeField] private UnityEvent TriggerExit;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision objeto)
    {
        if (objeto.transform.tag == "Player")
        {
            ColliderEnter.Invoke();

        }


    }

    private void OnTriggerStay(Collider objeto)
    {
        if (objeto.transform.tag == "Player")
        {
            TriggerStay.Invoke();

        }

    }

    private void OnTriggerExit(Collider objeto)
    {

        if (objeto.transform.tag == "Player")
        {
            TriggerExit.Invoke();
        }

    }
}
