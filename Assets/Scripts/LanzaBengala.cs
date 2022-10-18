using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaBengala : MonoBehaviour
{
    public Transform Spawnbengala;
    public GameObject Bengala;
    public float range = 25f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            LanzarBengala();
        }
    }

    void LanzarBengala()
    {
        GameObject copiarBengala = Instantiate(Bengala, Spawnbengala.position, Spawnbengala.rotation);
        copiarBengala.GetComponent<Rigidbody>().AddForce(Spawnbengala.forward * range, ForceMode.Impulse);     
    }
}

