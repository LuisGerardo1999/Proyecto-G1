using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionG : MonoBehaviour
{
    public GameObject efectoExplosion;//Particulas
    public GameObject VFXexplosion2;//Particulas2
    public float delay = 3f;
    float radius = 20f;
    public float explosionForce = 10f;

    void Start()
    {
        Invoke("ExplotarGranada", delay);
    }

    
    void Update()
    {
        
    }

    void ExplotarGranada()
    {
        //Detectar colliders cercanos
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);

        //Apply Force
        foreach(Collider cercanos in colliders)
        {
            Rigidbody rb = cercanos.GetComponent<Rigidbody>();
            if(rb !=null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, radius,1f,ForceMode.Impulse);
            }
            //InstanciarParticulas
            Instantiate(efectoExplosion, transform.position, transform.rotation);
            Instantiate(VFXexplosion2, transform.position, transform.rotation);

            Destroy(gameObject); //Destruir Granada
        }
    }
}
