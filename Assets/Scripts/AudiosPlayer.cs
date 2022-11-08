using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip aCaminar;
    public AudioClip aCorrer;

    private void Start()
    {
    

    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S)) && !(Input.GetKeyDown(KeyCode.LeftShift)))
        {
            sCaminar();
            Debug.Log("NUEVO AUDIO CAMINAR");
        }

        if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)) && !(Input.GetKeyUp(KeyCode.LeftShift))) { sPause(); }


        if ((Input.GetKeyDown(KeyCode.LeftShift)) && (Input.GetKeyDown(KeyCode.W)) || (Input.GetKeyDown(KeyCode.S)))
        {
            sCaminar();
            Debug.Log("NUEVO AUDIO CORRER");
        }
        if ((Input.GetKeyUp(KeyCode.LeftShift)) && (Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S))) { sPause(); }

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



}
