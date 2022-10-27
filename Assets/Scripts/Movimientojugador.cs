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
    private float velocidad = 0.009f;


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



    void Start()
    {
         vida = 5;
         suministroImportante = 5;
         salto = new Vector3(0.0f, 5.0f, 0.0f);  

    }
    void Update()
    {
       
        movimiento();
        cambioArma();
 
        
    }

 

    private void movimiento()
    {
       
        var anim = GetComponent<Animator>();

        // Caminar
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            //this.caminar = true;
            anim.SetBool("IsCaminar", true);
        }
        else
        {
            anim.SetBool("IsCaminar", false);
           // this.caminar = false;

            //if (Input.GetKeyUp(KeyCode.UpArrow))
            //{
            //    audioSource.Stop();
            //}
        }


        //if (this.caminar == true)
        //{
        ////    audioSource = GetComponent<AudioSource>();
        ////    audioSource.clip = soundCaminar;
        //    Debug.Log("Musica Caminar");
        //   // audioSource.Play();


        //    var sonidoCaminar = GetComponent<AudioSource>();
        //     sonidoCaminar.clip = soundCaminar;
        //    sonidoCaminar.Play();
            
        //}

        //if (this.caminar == false)
        //{ 
        //    Debug.Log("Musica Parar");
        //    audioSource.Pause();
        //}



        //Correr
        if ((Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            velocidad = 0.09f;
            anim.SetBool("IsCorrer", true);

            //audioSource.clip = soundCorrer;
            //audioSource.Play();
        }
        else{
            velocidad = 0.009f;
            anim.SetBool("IsCorrer", false);
           // audioSource.Stop();
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
        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetBool("IsSaltar", true);
            movRbPlayer.AddForce(salto,ForceMode.Impulse);
        }else anim.SetBool("IsSaltar", false);



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
        transform.Translate(Input.GetAxis("Horizontal") * velocidad, 0, Input.GetAxis("Vertical") * velocidad);
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
