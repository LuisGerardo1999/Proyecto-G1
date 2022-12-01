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
    int pick;


    // Variambles Menu
    public float vida;
    public int municion;
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
    public GameObject hacha, pistola, botiquin, ak47, m4a1, rifle, granada;
    //public enum armas { nada, pistola, botiquin, ak47, m4a1, rifle, granada };
    //public armas tipoArma;

    int municPistola = 0, municAk47 = 0, municM4a1 = 0, municRifle = 0, municGranada = 0;


    public float salt = 0f;
    public int bandArma = 0;
    private int contador = 0;

    //camara
    public GameObject camarV;
    public GameObject miraV;

    //private void Awake()
    //{
    //    SingleMenu.instanciaUnica.GetSingletonVida();
        
    //}

    void Start()
    {
         vida = 5;
         suministroImportante = 5;
         this.pick = 0;

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

        //Caminar
        if (((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))) && !(Input.GetKey(KeyCode.LeftShift)) && !(Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.LeftControl)))
        {
            //this.caminar = true;
            anim.SetBool("IsWalking", true);
            
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        // Caminar Derecha
        if ( ( ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.D)) )  || ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.S))) ) && !(Input.GetKey(KeyCode.LeftShift)) )
        {
            anim.SetBool("IsWRight", true);
            anim.SetBool("IsWalking", true);
            transform.Rotate(0, 0.9f, 0);
            //Quaternion quat = Quaternion.Euler(0f, Input.GetAxis("Mouse X") + 90f, 0f);
        }
        else
        {
            anim.SetBool("IsWRight", false);
            
        }


        // Caminar Izquierda
        if ((((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.A)) || ((Input.GetKey(KeyCode.D)) && (Input.GetKey(KeyCode.S)))) && !(Input.GetKey(KeyCode.LeftShift)) ))
        {
            anim.SetBool("IsWLeft", true);
            anim.SetBool("IsWalking", true);
            transform.Rotate(0, -0.9f, 0);
        }
        else
        {
            anim.SetBool("IsWLeft", false);
            
        }

        //Derecho
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            //this.caminar = true;
            anim.SetBool("IsRight", true);
        }
        else
        {
            anim.SetBool("IsRight", false);
        }


        //Izquierdo
        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.W) ) && !(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.LeftShift)))
        {
            //this.caminar = true;
            anim.SetBool("IsLeft", true);
        }
        else
        {
            anim.SetBool("IsLeft", false);
        }
        //Correr
        if ((Input.GetKey(KeyCode.LeftShift)) && (bandArma == 0)  && ( (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S))  || (Input.GetKey(KeyCode.A))  || (Input.GetKey(KeyCode.D)) ) )
        {
            velocidad = 2.9f;
            anim.SetBool("IsRun", true);
        }
        else{
            
            anim.SetBool("IsRun", false);           
        }

        //Correr con arma
        if ((Input.GetKey(KeyCode.LeftShift)) && (bandArma != 0) && ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))))
        {
            velocidad = 2.9f;
            anim.SetBool("IsWalking", true);
        }
        //else
        //{

        //    anim.SetBool("IsWalking", false);
        //}



        // pick medio
        if ((Input.GetKey(KeyCode.T)) && (pick == 1))
        {
           anim.SetBool("Pick40", true);
        }
        else
        {

            anim.SetBool("Pick40", false);
        }

        // pick medio

        if ((Input.GetKey(KeyCode.T)) )//&& (pick == 2))
        {
            anim.SetBool("Pick80", true);
        }
        else
        {

            anim.SetBool("Pick80", false);
        }


        // pick alto

        if ((Input.GetKey(KeyCode.T)) && (pick == 3))
        {
            anim.SetBool("Pick100", true);
        }
        else
        {

            anim.SetBool("Pick100", false);
        }


        // Agacharse
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("IsBend", true);
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("AgachCaminar", true);
            }
            
        }
        else
        {
            anim.SetBool("IsBend", false);
            anim.SetBool("AgachCaminar", false);
        }

        //Salto
        if (enPiso == true && Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
            movRbPlayer.AddForce(salto,ForceMode.Impulse);
        }else anim.SetBool("IsJumping", false);



        /////////////////////////////////////   MOVIMIENTO ARMAS 

        if (bandArma == 0)
        {
            anim.SetBool("IsBotiquin", true);
        }
        else
        {
            anim.SetBool("IsBotiquin", false);
        }


        // Disparar Luger
        if ( (bandArma ==1) || (bandArma == 7))
        {
                anim.SetBool("IsGunIdle", true);
        }
        else
        {
                anim.SetBool("IsGunIdle", false);
        }

        if (bandArma == 3 || bandArma == 4 || bandArma == 5)
        {
            anim.SetBool("IsRifleIdle", true);
        }
        else
        {
            anim.SetBool("IsRifleIdle", false);
        }


        // Granada
        if (Input.GetKey(KeyCode.G))
        {
            anim.SetBool("IsGranada", true);
        }
        else
        {
            anim.SetBool("IsGranada", false);
        }

        //hacha
        if ((bandArma == 2))
        {
            anim.SetBool("IsHacha", true);
        }
        else
        {
            anim.SetBool("IsHacha", false);
        }

        // Recargar
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("IsReload", true);
        }
        else
        {
            anim.SetBool("IsReload", false);
        }

        //DISPARAR

        if (Input.GetMouseButtonDown(0) &&  ( (bandArma ==1 ) || (bandArma == 3) || (bandArma == 4) || (bandArma == 5) || (bandArma == 7)) )
        {
            anim.SetBool("IsGunShoot", true);
        }
        else
        {
            anim.SetBool("IsGunShoot", false);
        }

        //// Ataque Hacha
        if (Input.GetMouseButtonDown(0) && ((bandArma == 2)))
        {
            anim.SetBool("IsHachaAttack", true);
        }
        else
        {
            anim.SetBool("IsHachaAttack", false);
        }


        ////Movimiento, variable de prueba velocidad para correr.
        transform.Translate(Input.GetAxis("Horizontal") * velocidad*Time.deltaTime, 0, Input.GetAxis("Vertical") * velocidad * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);


        if (bandArma == 1 || bandArma == 2 || bandArma == 3 || bandArma == 4 || bandArma == 5)
        {
            camarV.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
            if(bandArma !=2)
            {
                miraV.SetActive(true);
            }else miraV.SetActive(false);

        }
        else
        {
            camarV.transform.Rotate(0, 0, 0);
            miraV.SetActive(false);
        }



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

          
        if (other.transform.tag == "municPistola")
        {
            municPistola += 10;
            Destroy(other.transform.gameObject);
            

        }

        if (other.transform.tag == "municAk47")
        {
            municPistola += 8;
            Destroy(other.transform.gameObject);
            Debug.Log(municAk47);
            
        }

        if (other.transform.tag == "municM4a1")
        {
            municPistola += 8;
            Destroy(other.transform.gameObject);
            Debug.Log(municM4a1);
           
        }

        if (other.transform.tag == "municRifle")
        {
            municPistola += 4;
            Destroy(other.transform.gameObject);
            Debug.Log(municRifle);
            
        }

        if (other.transform.tag == "municGranada")
        {
            municPistola += 5;
            Destroy(other.transform.gameObject);
            Debug.Log(municGranada);
        }


        if (other.transform.tag == "pick40")
        {
            this.pick = 1;
        }

        if (other.transform.tag == "pick80")
        {
            this.pick = 2;
        }

        if (other.transform.tag == "pick100")
        {
            this.pick = 3;
        }

        if (other.transform.tag == "n1")
        {
            SingleMenu.instanciaUnica.SetSingletonVida(vida);
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

        if (other.transform.tag == "n4")
        {
            SceneManager.LoadScene(0);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "pick40")
        {
            this.pick = 0;
        }

        if (other.transform.tag == "pick80")
        {
            this.pick = 0;
        }

        if (other.transform.tag == "pick100")
        {
            this.pick = 0;
        }

    }


    //void OnCollisionEnter(Collision collision)
    void OnCollisionStay(Collision collision)
    {


        if (collision.transform.tag == "enemigo1")
        {

            Debug.Log("Player vida " + vida);
            //Debug.Log(vida);
            vida -= 0.01f;
        }

        if (collision.transform.tag == "enemigo1")
        {

            Debug.Log("MURO PLAYER");
            
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


        //SELECCION DE ARMA
        if (Input.GetKeyDown(KeyCode.F))
        {
            contador += 1;
            if (contador % 2 == 0)
            {

                bandArma = 0;
                Debug.Log(bandArma);
            }
            if (contador % 2 != 0)
            {
                bandArma = 1;
                Debug.Log(bandArma);
            }

        }
        if (Input.GetKeyDown("1"))
        {
            bandArma = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            bandArma = 2;
        }
        if (Input.GetKeyDown("3"))
        {
            bandArma = 3;
        }
        if (Input.GetKeyDown("4"))
        {
            bandArma = 4;
        }
        if (Input.GetKeyDown("5"))
        {
            bandArma = 5;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            bandArma = 6;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bandArma = 7;
        }
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    bandArma = 8;
        //}


        //ACTIVACION DE ARMA

        switch (bandArma)
        {
            case 0:
                {
                    pistola.SetActive(false);
                    botiquin.SetActive(false);
                    ak47.SetActive(false);
                    m4a1.SetActive(false);
                    rifle.SetActive(false);
                    granada.SetActive(false);
                    hacha.SetActive(false);

                    break;
                }

            case 1:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(true);
                    botiquin.SetActive(false);
                    ak47.SetActive(false);
                    m4a1.SetActive(false);
                    rifle.SetActive(false);
                    granada.SetActive(false);
                    hacha.SetActive(false);
                    break;
                }

            case 2:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(false);
                    botiquin.SetActive(false);
                    ak47.SetActive(false);
                    m4a1.SetActive(false);
                    rifle.SetActive(false);
                    granada.SetActive(false);
                    hacha.SetActive(true);
                    break;
                }
            case 3:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(false);
                    botiquin.SetActive(false);
                    ak47.SetActive(true);
                    m4a1.SetActive(false);
                    rifle.SetActive(false);
                    granada.SetActive(false);
                    hacha.SetActive(false);
                    break;
                }

            case 4:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(false);
                    botiquin.SetActive(false);
                    ak47.SetActive(false);
                    m4a1.SetActive(true);
                    rifle.SetActive(false);
                    granada.SetActive(false);
                    hacha.SetActive(false);
                    break;
                }

            case 5:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(false);
                    botiquin.SetActive(false);
                    ak47.SetActive(false);
                    m4a1.SetActive(false);
                    rifle.SetActive(true);
                    granada.SetActive(false);
                    hacha.SetActive(false);
                    break;
                }
            case 6:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(false);
                    botiquin.SetActive(false);
                    ak47.SetActive(false);
                    m4a1.SetActive(false);
                    rifle.SetActive(false);
                    granada.SetActive(true);
                    hacha.SetActive(false);
                    break;
                }

            case 7:
                {
                    Debug.Log(bandArma);
                    pistola.SetActive(false);
                    botiquin.SetActive(true);
                    ak47.SetActive(false);
                    m4a1.SetActive(false);
                    rifle.SetActive(false);
                    granada.SetActive(false);
                    hacha.SetActive(false);
                    break;
                }

            //case 8:
            //    {
            //        Debug.Log(bandArma);
            //        pistola.SetActive(true);
            //        botiquin.SetActive(false);
            //        ak47.SetActive(false);
            //        m4a1.SetActive(false);
            //        rifle.SetActive(false);
            //        granada.SetActive(false);
            //        hacha.SetActive(false);
            //        break;
            //    }

        }




    }

}
