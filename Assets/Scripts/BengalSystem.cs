using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BengalSystem : MonoBehaviour
{
    public GameObject Estela1;//Particulas
    public GameObject Disparo;//Particulas2
    public float delay = 2f;

    void Start()
    {
        Invoke("DestruirParticulas", delay);
    }

    
    void Update()
    {
        Instantiate(Estela1, transform.position, transform.rotation);
        Instantiate(Disparo, transform.position, transform.rotation);

        
    }

    void DestruirParticulas()
    {
        Destroy(gameObject);
    }
}
