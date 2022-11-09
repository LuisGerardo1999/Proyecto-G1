using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCarta : MonoBehaviour
{
    public Informacion _InfoEnemigo;
    public Informacion _InfoEnemigo1;
    public Informacion _InfoEnemigo2;
    public Informacion _InfoEnemigo3;
    public Informacion _InfoEnemigo4;
    public Informacion _InfoEnemigo5;
    public Text textoDescripcion;
    public Image ImagenCarta;
    public Text Nombre;

    void Start()
    {
         _InfoEnemigo = _InfoEnemigo1;
    }

    private void Update()
    {
        textoDescripcion.text = _InfoEnemigo.descripcionCarta;
         Nombre.text = _InfoEnemigo.nombreCarta;
         ImagenCarta.sprite = _InfoEnemigo.dibujoCarta;
    }
    public void CambiarEnemigoUno()
    {
        _InfoEnemigo = _InfoEnemigo1;
    }

        public void CambiarEnemigoDos()
    {
        _InfoEnemigo = _InfoEnemigo2;
    }

        public void CambiarEnemigoTres()
    {
        _InfoEnemigo = _InfoEnemigo3;
    }

        public void CambiarEnemigoCuatro()
    {
        _InfoEnemigo = _InfoEnemigo4;
    }

        public void CambiarEnemigoCinco()
    {
        _InfoEnemigo = _InfoEnemigo5;
    }
}
