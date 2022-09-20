using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


   //variable RigidBody
    [SerializeField]
    private Rigidbody movRbPlayer;

    public Vector3 salto;
    

    void Start()
    {
         vida = 5;
         suministroImportante = 5;
         salto = new Vector3(0.0f, 5.0f, 0.0f);

    }
    void Update()
    {
        movimiento();
        

    }

    

    private void movimiento()
    {
        var anim = GetComponent<Animator>();


        // Caminar Adelante
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.DownArrow))){

            anim.SetBool("IsCaminar", true);
        }
        else
        {
            anim.SetBool("IsCaminar", false);
        }


        //Correr
        if (Input.GetKey(KeyCode.LeftShift)){
            velocidad = 0.09f;
            anim.SetBool("IsCorrer", true);
        }
        else{
            velocidad = 0.009f;
            anim.SetBool("IsCorrer", false);
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



        ////Movimiento, variable de prueba velocidad, eliminar al final
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
    }
}
