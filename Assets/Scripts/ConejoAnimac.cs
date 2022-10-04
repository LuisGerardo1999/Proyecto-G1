using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejoAnimac : MonoBehaviour
{

    public Transform player1Transf;
    Animator animacion;
    float tiempoTranscurrido;
    float tiempoInicial = 10.0f;
    public Vector3 salto = new Vector3(0.0f, 3f, 0.0f);
    Rigidbody rigidbody;

    // variables temporales
    public float velocidadConejo;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponent<Animator>();
        tiempoTranscurrido = tiempoInicial;
        rigidbody = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

        //Random.Range(0, 5);

        //Temporizador segundos
        tiempoTranscurrido -= Time.deltaTime;

        Debug.Log(tiempoTranscurrido);
        
        // movimiento conejo 
        if(tiempoTranscurrido < 3.0f)
        {
            animacion.SetBool("IsJumpConejo", true);
        }else animacion.SetBool("IsJumpConejo", false); 
            
            if(tiempoTranscurrido <= 0)
            {

                tiempoTranscurrido = tiempoInicial;
            }

        //% LUIS


        // Inicia ataque
        float distancia = Vector3.Distance(transform.position, player1Transf.position);
        
        if (distancia < 8.41f)
        {
            animacion.SetBool("IsJumpConejo", false);
            animacion.SetBool("IsGuardConejo", true);


            if (distancia < 8f)
            {
                animacion.SetBool("IsRunConejo", true);
                transform.LookAt(player1Transf);
                transform.position = Vector3.MoveTowards(transform.position, player1Transf.position , velocidadConejo * Time.deltaTime ); ;

                //Salto
                if (distancia< 0.8f)
                {    
                    
                   rigidbody.AddForce(salto, ForceMode.Impulse);
                }
               


            }
            else animacion.SetBool("IsRunConejo", false);


        }  else animacion.SetBool("IsGuardConejo", false);

    }
}
