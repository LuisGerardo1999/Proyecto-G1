using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybengal : MonoBehaviour
{
    public float TiempoBengala;

    void Start()
    {
        
    }


    void Update()
    {
        Destroy(gameObject,TiempoBengala);
    }
}
