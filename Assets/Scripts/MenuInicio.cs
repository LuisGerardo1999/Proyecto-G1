using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelOpcion;
    public GameObject panelCreditos;
    public GameObject panelInicio;


    public void botonInicio()
    {
        SceneManager.LoadScene(1);
    }

    public void botonSalir()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void botonOpciones()
    {
        panelOpcion.SetActive(true);
        panelCreditos.SetActive(false);
        panelInicio.SetActive(false);
    }

    public void botonCreditos()
    {
        panelCreditos.SetActive(true);
        panelOpcion.SetActive(false);
        panelInicio.SetActive(false);
    }

    public void PausaPanel()
    {
        //PanelPausa.SetActive(true);
        //Time.timeScale = 0;
    }

    public void botonRegresar()
    {
        panelInicio.SetActive(true);
        panelCreditos.SetActive(false);
        panelOpcion.SetActive(false);
    }

}
