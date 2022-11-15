using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    public Image Barravuda;
    public float vidaUI;


    void Start()
    {
        vidaUI = 100;
        Barravuda.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibirGolpeTigre()
    {
        vidaUI = vidaUI - 5;
        Barravuda.fillAmount = vidaUI / 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "EnemigoTigre")
        {
            RecibirGolpeTigre();
        }
    }
}
