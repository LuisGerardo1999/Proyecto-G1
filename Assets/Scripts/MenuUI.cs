using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

   public GameObject PanelPausa;
   public GameObject PanelOptions;

   public void BotonInicio()
   {
       SceneManager.LoadScene(1);
   }

   public void PausaPanel()
   {
        PanelPausa.SetActive(true);
        Time.timeScale = 0;
   }

   public void Reanudar()
   {
        PanelPausa.SetActive(false);
        Time.timeScale = 1;
   }
   public void ActivarOptionsEnemigos()
   {
          PanelOptions.SetActive(true);
          PanelPausa.SetActive(false);
   }

   public void DesactivarOptionsEnemigos()
   {
          PanelOptions.SetActive(false);
   }
}
