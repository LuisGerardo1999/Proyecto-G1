using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevaCarta", menuName = "Carta_Enemy")]

public class Informacion : ScriptableObject
{
    public string nombreCarta;
    public string descripcionCarta;
    public Sprite dibujoCarta;
  

    public void MostrarCarta()
    {
        Debug.Log(nombreCarta + ": " + descripcionCarta);
    }

}

