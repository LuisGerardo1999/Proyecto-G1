using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimientojugador : MonoBehaviour
{
    //GameObject
    //public GameObject player;


    // Variables movimiento
   private float velocidad;
    public Transform enPisoPos;
    private bool enPiso;
    public LayerMask piso;


    // Variambles Menu
    public int vida;
    public int municion;
    public int botiquin;
    public int suministroImportante;
    public Transform Arma;

    // audio
    //public AudioSource audioSource; 
    //public AudioClip soundCaminar, soundCorrer;

   //variable RigidBody
    [SerializeField]
    private Rigidbody movRbPlayer;
    public Vector3 salto;

    //BOOLEANAS
    private Boolean caminar;
    private Boolean correr;


    // armas
    public GameObject cuchillo, pistola, revolver, ak47, escopeta, ametralladora, arma;
    public enum armas { cuchillo, pistola, revolver, ak47, escopeta, ametralladora, nada };
    public armas tipoArma;

    public float salt = 0f;

    void Start()
    {
         vida = 5;
         suministroImportante = 5;
         

    }
    void Update()
    {
       
        movimiento();
        cambioArma();
 
        
    }

 

    private void movimiento()
    {
        velocidad = 1.3f;
        salto = new Vector3(0.0f, salt, 0.0f);
        
        if(Physics.CheckSphere(enPisoPos.position, 0.9f, piso) == true)
        {
            enPiso = true;
        }else enPiso = false;


        var anim = GetComponent<Animator>();


    // moverse adelante W, moverse atrás S, moverse a la izquierda A,  moverse a la derecha D

        // Caminar
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            //this.caminar = true;
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        //Correr
        if ((Input.GetKey(KeyCode.LeftShift)) && ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))))
        {
            velocidad = 7f;
            anim.SetBool("IsRun", true);
        }
        else{
            
            anim.SetBool("IsRun", false);           
        }

        // Agacharse
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("IsAgacharse", true);
            Debug.Log("AGACHARSE");
        }
        else
        {
            anim.SetBool("IsAgacharse", false);
        }

        //Salto
        if (enPiso == true && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
            movRbPlayer.AddForce(salto,ForceMode.Impulse);
        }else anim.SetBool("IsJumping", false);



        //// Caminar Atras
        //if (Input.GetKey(KeyCode.DownArrow))
        //{

        //    anim.SetBool("IsCaminar", true);
        //    ////Movimiento, variable de prueba velocidad, eliminar al final

        //}
        //else
        //{
        //    anim.SetBool("IsCaminar", false);
        //}



        ////Movimiento, variable de prueba velocidad para correr.
        transform.Translate(Input.GetAxis("Horizontal") * velocidad*Time.deltaTime, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        
        

        
        
    }

    private void movimientoEfecto()
    {
        // solo para efecto de movimiento.
        //Movimiento, variable de prueba velocidad, eliminar al final
        movRbPlayer.AddForce(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Comida")
        {
            vida += 20;
            Destroy(other.transform.gameObject);
            Debug.Log("La cantidad de vida es:  " + vida);
        }

        if(other.transform.tag == "n1")
        {
            SceneManager.LoadScene(2);
        }

        if (other.transform.tag == "n2")
        {
            SceneManager.LoadScene(3);
        }

        if (other.transform.tag == "n3")
        {
            SceneManager.LoadScene(4);
        }

    }



    //public void cambioArma()
    //{
    //   public enum armas { cuchillo, pistola, revolver, ak47, escopeta, ametralladora};
    //public GameObject cuchillo, pistola, revolver, ak47, escopeta, ametralladora, arma;
    //public armas 

    //    switch()
    //    {

    //        case armas.cuchillo:
    //            {
    //                Debug.Log("Cuchillo");
    //                break;
    //            }

    //    }


    //}

    private void cambioArma()
    {
        //switch (tipoArma)
        //{

            pistola.SetActive(armas.pistola == tipoArma);
            ak47.SetActive(armas.ak47 == tipoArma);

        //case armas.cuchillo:
        //    {
        //        Debug.Log("Cuchillo");
        //        break;
        //    }
        //    case armas.pistola:
        //    {
        //        Debug.Log("Pistola");

        //        pistola.SetActive(armas.pistola == tipoArma);
        //        break ;
        //    }
        //case armas.revolver:
        //    {
        //        Debug.Log("Revolver");
        //        break;
        //    }
        //case armas.ak47:
        //    {
        //        Debug.Log("AK47");
        //        ak47.SetActive(true);
        //        break;
        //    }
        //case armas.escopeta:
        //    {
        //        Debug.Log("Escopeta");
        //        break;
        //    }
        //case armas.ametralladora:
        //    {
        //        Debug.Log("nada");
        //        break;
        //    }

        //}





       
    }










}
