using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTexto : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textoKim;
    float tiempoFinal = 0;
    float tiempoInicial = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Cientifico")
        {
            StartCoroutine(textCientifico());

        }

        if (other.transform.name == "timeMachineMiddle")
        {
            StartCoroutine(textMaquinaTiempo());
        }


        if (other.transform.tag == "municPistola")
        {
       
            textoKim.text = " Pistola +10";
        }

        if (other.transform.tag == "municAk47")
        {
            textoKim.text = " AK47 +8";
        }

        if (other.transform.tag == "municM4a1")
        {
            textoKim.text = " M4A1 +8";
        }

        if (other.transform.tag == "municRifle")
        {
            textoKim.text = " Rifle +4";
        }

        if (other.transform.tag == "municGranada")
        {
            textoKim.text = " Granada +5";
        }
    }

        IEnumerator textCientifico()
    {
        textoKim.fontSize = 10;
        textoKim.text = "Hola Kim, Carl se volvio loco";
        yield return new WaitForSeconds(3);
        textoKim.text = "trato de matarnos a todos,";
        yield return new WaitForSeconds(3);
        textoKim.text = "Hizo que varios de los animales ingresaran";
        yield return new WaitForSeconds(3);
        textoKim.text = "Consigue los suministros ";
        yield return new WaitForSeconds(3);
        textoKim.text = "y libera la zona antes que nos maten";
        yield return new WaitForSeconds(3);
        textoKim.text = "Consigue los suministros ";
        yield return new WaitForSeconds(3);

    }


    IEnumerator textMaquinaTiempo()
    {
        textoKim.fontSize = 10;
        textoKim.text = "Cambia de arma 1 - 5";
        yield return new WaitForSeconds(3);
        textoKim.text = "Salta con Barra Espaciadora";
        yield return new WaitForSeconds(3);
        textoKim.text = "Granada: G";
        yield return new WaitForSeconds(3);
        textoKim.text = "Hacha: Q";
        yield return new WaitForSeconds(3);
        textoKim.text = "Agarra comida con T";
        yield return new WaitForSeconds(3);
        textoKim.text = "Arriba, Abajo: W, S";
        yield return new WaitForSeconds(3);
        textoKim.text = "Izquierda, Derecha: A, D";
        yield return new WaitForSeconds(3);
        textoKim.text = "Consigue los suministros ";
        
    }
   

}
