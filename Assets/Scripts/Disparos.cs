using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{

    public GameObject pointSpawnGun;
    public GameObject pointSpawnRifle;
    public GameObject pointSpawnGranada;
    public GameObject pointSpawnMira;
    public float rango = 50f;
    public float rangoBengala = 35f;

    public GameObject efectoDisparo;
    public GameObject efectoDisparo2;
    public GameObject bengala;
    public GameObject efectoGolpeDiparo;
    public Movimientojugador baArma;

    private void Update()
    {
        baArma = FindObjectOfType<Movimientojugador>();
       

        if (Input.GetMouseButtonDown(0) && (baArma.bandArma ==1))
        {
            disparar();
        }

        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 3 || baArma.bandArma == 4 || baArma.bandArma == 5))
        {
            disparar2();
        }


        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 7))
        {
            LanzarBengala();
        }



       // pointSpawnMira.transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

    }


    void disparar()
    {
        Instantiate (efectoDisparo, pointSpawnGun.transform.position, pointSpawnGun.transform.rotation);
        RaycastHit hit;

        if (Physics.Raycast(pointSpawnMira.transform.position, pointSpawnMira.transform.forward, out hit, rango))
        {
            
            Instantiate(efectoGolpeDiparo, hit.point, Quaternion.LookRotation(hit.normal));
            Danho danio = hit.transform.GetComponent<Danho>();
            if(danio != null)
            {
                danio.danho(20.5f);
            }
        }
    }


    void disparar2()
    {
        Instantiate(efectoDisparo2, pointSpawnRifle.transform.position, pointSpawnRifle.transform.rotation);
        RaycastHit hit;

        if (Physics.Raycast(pointSpawnMira.transform.position, pointSpawnMira.transform.forward, out hit, rango))
        {
            //hit.transform.position
           
            Instantiate(efectoGolpeDiparo, hit.point, Quaternion.LookRotation(hit.normal));
            Danho danio = hit.transform.GetComponent<Danho>();
            if (danio != null)
            {
                danio.danho(33.5f);
            }
        }
    }

    void LanzarBengala()
    {
        GameObject copiarBengala = Instantiate(bengala, pointSpawnGranada.transform.position, pointSpawnGranada.transform.rotation);
        copiarBengala.GetComponent<Rigidbody>().AddForce(pointSpawnGranada.transform.forward * rangoBengala, ForceMode.Impulse);
    }
    //-Input.GetAxis("Mouse Y")*3

}