using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToroMuebles : MonoBehaviour
{
    private int numero;
    // Start is called before the first frame update
    void Start()
    {
        numero = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(numero >= 2)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemigo1")
        {
            numero += 1;
        }
    }
}
