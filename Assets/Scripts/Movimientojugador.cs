using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador : MonoBehaviour
{



    public float velocidad = 0.8f;
    public int vida;
    public int municion;
    public int botiquin;
    public int suministroImportante;
    public Transform Arma;

    [SerializeField]
    private Rigidbody movRbPlayer;

    void Start()
    {
         vida = 100;
         suministroImportante = 5;
    }
    void Update()
    {
        movimiento();
    }

    private void movimiento()
    {


        //variables movimiento

        //float movHorizontal = Input.GetAxis("Horizontal");
        //float movVertical = Input.GetAxis("Vertical");
        //float movRotacion = Input.GetAxis("Mouse X");
        //Vector3 desplazamiento = new Vector3(movHorizontal, movRotacion, movVertical);
        //transform.Translate(desplazamiento*velocidad);

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


    private void OnTriggerEnter(Collider other)
    {
      
         if (other.transform.tag == "Municion")
         {
             municion++;
             Destroy(other.transform.gameObject);
             Debug.Log ("Puedes recargar tus armas con R ");
         }
         if (other.transform.tag == "Botiquin")
         {
              botiquin++;
              Destroy(other.transform.gameObject);
              Debug.Log ("Usa el Botiquin para recuperar vida");
         }
         if (other.transform.tag == "SuministroImportante")
         {
              suministroImportante -- ;
              Destroy(other.transform.gameObject);       
         }
    
    }
}
