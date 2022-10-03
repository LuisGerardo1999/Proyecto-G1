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
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    public void sCaminar()
    {
        audioSource.clip = aCaminar;
        audioSource.Play();

    }

    public void sCorrer()
    {
        audioSource.clip = aCorrer;
        audioSource.Play();
    }



}
