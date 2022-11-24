using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarToro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetoActivar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            objetoActivar.SetActive(true);
        }
    }
}
