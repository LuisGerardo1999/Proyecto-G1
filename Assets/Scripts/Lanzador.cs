using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject granda;
    public float range = 50f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            LanzarGranada();
        }
    }

    void LanzarGranada()
    {
        GameObject copiarGranada = Instantiate(granda,spawnPoint.position,spawnPoint.rotation);
        copiarGranada.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);     
    }
}
