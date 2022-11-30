using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioToro : MonoBehaviour
{
    public GameObject portal;
    private float life;
    private void Start()
    {
        life = Random.Range(280, 320);
    }


    public void danho(float cantidad)
    {

        Debug.Log(transform.name + " VIDA: " + life);
        life -= cantidad;
        if (life < 0)
        {
            portal.SetActive(true);
            Destroy(gameObject);
            

        }
    }


    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.tag == "arma1")
        {
            Debug.Log(transform.name + " VIDA: " + life);
            life -= 51.5f;
            if (life < 0)
            {
                portal.SetActive(true);
                Destroy(gameObject);
            }
        }

    }


}
