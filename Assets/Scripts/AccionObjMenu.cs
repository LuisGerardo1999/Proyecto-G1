using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionObjMenu : MonoBehaviour
{
    public GameObject objetoAccion;

    public void destruirObj()
    {
        
        Destroy(objetoAccion);
        Debug.Log("Activado");

    }




}
