using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterfaz : MonoBehaviour
{

    public Image barraVida;
    public Movimientojugador playerVida;
    float playerVidaActual;
    // Start is called before the first frame update
    void Start()
    {
        barraVida.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        playerVida = FindObjectOfType<Movimientojugador>();
        playerVidaActual = (float) playerVida.vida;
        barraVida.fillAmount = playerVidaActual / 100; 
        Debug.Log(playerVidaActual);
    }
}
