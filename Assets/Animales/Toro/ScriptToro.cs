using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptToro : MonoBehaviour
{
    private float grado = 0;
    private Quaternion angulo;
    public Transform transformPlayer;
    public Transform campoFinal;
    public Animator anima;
    int ataq = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }

    private void movimiento()
    {
        anima = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("detecta colision");
            anima.SetBool("IsCornada", false);
            anima.SetBool("IsGarra", true);
            ataq += 1;
            Debug.Log("ataque: " + ataq);
            if (ataq == 3)
            {
                anima.SetBool("IsGarra", false);
                anima.SetBool("IsCornada", true);
                ataq = 0;

            }
        }
        else
        {
            Debug.Log("sale de colision");
            anima.SetBool("IsGarra", false);
            anima.SetBool("IsCornada", false);
        }

        if (collision.transform.tag == "muro")
        {
            transform.LookAt(transformPlayer);
            Debug.Log("perro muro");
            transform.position = Vector3.MoveTowards(transform.position, transformPlayer.transform.position, Time.deltaTime);
            //transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        //else
        //{

        //    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        //}

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("perro trigguer");
        if (other.transform.name == "campoFinal")
        {
            transform.Translate(Vector3.forward * 1 * Time.deltaTime);
            //    }
            //    else //transform.LookAt(transformPlayer);
            ////}

            ////private void OnTriggerExit(Collider other)
            ////{
            ////    Debug.Log("perro trigguer exit");
            ////    if (other.transform.name == "campoFinal")
            //    {
            //        transform.LookAt(transformPlayer);
            //        Debug.Log("perro muro");
            //        transform.position = Vector3.MoveTowards(transform.position, transformPlayer.transform.position, Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = Vector3.MoveTowards(transform.position, campoFinal.transform.position, Time.deltaTime);
    }

}
