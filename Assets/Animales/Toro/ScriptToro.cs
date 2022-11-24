using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptToro : MonoBehaviour
{
    private float grado = 0;
    private Quaternion angulo;
    public Transform transformPlayer;
    public Transform campoFinal;
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
        
        
    }


    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "muro")
    //    {
    //        transform.LookAt(transformPlayer);
    //        Debug.Log("perro muro");
    //        transform.position = Vector3.MoveTowards(transform.position, campoFinal.transform.position, Time.deltaTime);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {

        Debug.Log("perro trigguer");
        if(other.transform.name == "campoFinal")
        {
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        else transform.LookAt(transformPlayer);


    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("perro trigguer exit");
        if (other.transform.name == "campoFinal")
        {
            transform.LookAt(transformPlayer);
            Debug.Log("perro muro");
            transform.position = Vector3.MoveTowards(transform.position, transformPlayer.transform.position, Time.deltaTime);
        }
        


    }

}
