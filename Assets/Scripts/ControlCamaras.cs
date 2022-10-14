using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamaras : MonoBehaviour
{
    
    public GameObject camaraFPS;
    public GameObject camaraFija;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarCamara();
    }

    public void CambiarCamara()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            camaraFija.SetActive(true);
            camaraFPS.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            camaraFija.SetActive(false);
            camaraFPS.SetActive(true);
        }
      
    }
}
