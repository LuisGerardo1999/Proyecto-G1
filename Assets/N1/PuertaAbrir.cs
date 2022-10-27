using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAbrir : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        var animPuerta = GetComponent<Animator>();
        if (other.gameObject.tag== "Player")
        {

            animPuerta.SetBool("isDoorOpen", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var animPuerta = GetComponent<Animator>();
        if (other.tag == "Player")
        {

            animPuerta.SetBool("isDoorOpen", false);
        }
    }
}
