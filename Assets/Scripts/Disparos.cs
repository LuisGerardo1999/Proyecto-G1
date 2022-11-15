using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{

    public GameObject pointSpawnGun;
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


        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 8))
        {
            LanzarBengala();
        }



    }


    void disparar()
    {
        Instantiate (efectoDisparo, pointSpawnGun.transform.position, pointSpawnGun.transform.rotation);
        RaycastHit hit;

        if (Physics.Raycast(pointSpawnGun.transform.position, pointSpawnGun.transform.forward, out hit, rango))
        {
            Debug.Log( hit.transform.gameObject);
        }
    }


    void disparar2()
    {
        Instantiate(efectoDisparo2, pointSpawnGun.transform.position, pointSpawnGun.transform.rotation);
        RaycastHit hit;

        if (Physics.Raycast(pointSpawnGun.transform.position, pointSpawnGun.transform.forward, out hit, rango))
        {
            Debug.Log(hit.transform.gameObject);
        }
    }

    void LanzarBengala()
    {
        GameObject copiarBengala = Instantiate(bengala, pointSpawnGun.transform.position, pointSpawnGun.transform.rotation);
        copiarBengala.GetComponent<Rigidbody>().AddForce(pointSpawnGun.transform.forward * rangoBengala, ForceMode.Impulse);
    }


}