using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensajes : MonoBehaviour
{
    public Text MensajesUI;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void ResetearText()
    {
        MensajesUI.text = "";
    }
    
}
