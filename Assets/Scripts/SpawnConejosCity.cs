using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnConejosCity : MonoBehaviour
{
    public GameObject PrefabEnemigo;

    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, 10);
    }

    void Update()
    {
        
    }

    void GenerarEnemigo()
    {
        Instantiate(PrefabEnemigo, transform.position, transform.rotation);
    }
}
