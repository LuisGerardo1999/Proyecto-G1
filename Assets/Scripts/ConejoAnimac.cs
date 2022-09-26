using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejoAnimac : MonoBehaviour
{

    public Transform player1Transf;
    Animator animacion;
    

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, player1Transf.position);

        if (distancia > 30)
        {
            animacion.SetBool("ConejoWalk", true);
        }

    }
}
