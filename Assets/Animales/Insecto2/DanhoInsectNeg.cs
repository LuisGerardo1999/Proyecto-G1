using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanhoInsectNeg : MonoBehaviour
{

    private float life;
    private void Start()
    {
        life = Random.Range(120, 220);
    }

    public void danho(float cantidad)
    {
        life -= cantidad;
        if (life < 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(transform.name + " VIDA: "+life);
        if (collision.transform.tag == "arma1")
        {
            life -= 51.5f;
            if (life < 0)
            {
                Destroy(gameObject);
            }
        }

        //if (collision.transform.tag == "arma2")
        //{

        //    life -= 33.5f;
        //    if (life < 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}

        //if (collision.transform.tag == "arma3")
        //{

        //    life -= 50.5f;
        //    if (life < 0)
        //    {
        //        Destroy(gameObject);
        //    }
        //}

    }
}
