using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirGranada : MonoBehaviour
{
    public float TiempoGranada;

    void Start()
    {
        
    }


    void Update()
    {
        Destroy(gameObject,TiempoGranada);
    }
}
