using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip aCaminar;
    public AudioClip aCorrer;
    public AudioClip pistola;
    public AudioClip sAK;
    public AudioClip sRifle;
    public AudioClip sBengala;
    public AudioClip sHacha;
    public Movimientojugador baArma;

    private void Start()
    {
    

    }

    private void Update()
    {
        baArma = FindObjectOfType<Movimientojugador>();

        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S)) && !(Input.GetKeyDown(KeyCode.LeftShift)))
        {
            sCaminar();
        }

        if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)) && !(Input.GetKeyUp(KeyCode.LeftShift))) { sPause(); }


        if ((Input.GetKeyDown(KeyCode.LeftShift)) && (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S)))
        {
            sCaminar();
        }
        if ((Input.GetKeyUp(KeyCode.LeftShift)) && (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S))) { sPause(); }


        // SONIDOS DISPAROS PISTOLA
        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 1))
        {
            sDisparar();
        }

        //SONIDO DISPARO AK y m4
        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 3 || baArma.bandArma == 4 ))
        {
            sDisparar2();
        }

        //SONIDO DISPARO Rifle
        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 5))
        {
            sDisparar3();
        }


        // Sonido Hacha
        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 2))
        {
            sDisparar4(); 
        }

        //SONIDO Bengala
        if (Input.GetMouseButtonDown(0) && (baArma.bandArma == 7))
        {
            sDisparar5();
        }
    }

    private void sPause()
    {
        audioSource.Pause();
    }

    public void sCaminar()
    {
        this.audioSource.clip = aCaminar;
        audioSource.Play();

    }

    public void sCorrer()
    {
        this.audioSource.clip = aCorrer;
        audioSource.Play();
    }

    // Disparos

    private void sDisparar()
    {
        this.audioSource.clip = pistola;
        audioSource.Play();

    }

    private void sDisparar2()
    {
        this.audioSource.clip = sAK;
        audioSource.Play();

    }

    private void sDisparar3()
    {
        this.audioSource.clip = sRifle;
        audioSource.Play();

    }

    private void sDisparar4()
    {
        this.audioSource.clip = sHacha;
        audioSource.Play();

    }

    private void sDisparar5()
    {
        this.audioSource.clip = sBengala;
        audioSource.Play();

    }


}
