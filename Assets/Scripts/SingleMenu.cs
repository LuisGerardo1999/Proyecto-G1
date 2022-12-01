using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static SingleMenu instanciaUnica;

    private float singletonVida;
    private void Awake()
    {
        if(SingleMenu.instanciaUnica == null)
        {
            SingleMenu.instanciaUnica = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("singleton: " + singletonVida);
    }


    public float GetSingletonVida()
    {
        return singletonVida;
    }

    public void SetSingletonVida(float vida)
    {
        singletonVida = vida;
    }

}
