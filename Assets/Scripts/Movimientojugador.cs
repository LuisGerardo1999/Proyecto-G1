using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador : MonoBehaviour
{
    public float velocidad;
    public int vida;
    public int municion;
    public int botiquin;
    public int suministroImportante;
    public Transform Arma;

    void Start()
    {
         vida = 100;
         suministroImportante = 5;
    }
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")* velocidad, 0, Input.GetAxis("Vertical")*velocidad);
        transform.Rotate(0,Input.GetAxis("Mouse X"), 0);
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
