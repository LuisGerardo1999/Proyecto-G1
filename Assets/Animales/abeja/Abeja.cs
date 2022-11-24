using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Abeja : MonoBehaviour
{
    public Transform PosicionPlayer;
    public float distPlayer;

    [SerializeField] private GameObject player;
    public NavMeshAgent navEnemigo;

    private float crono;
    public int evento;
    public Animator anima;
    private float grado =0;
    private Quaternion angulo;


    // Start is called before the first frame update
    void Start()
    {
        // EnemyNaveMesh = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia();
    }

    private void distancia()
    {
        distPlayer = Vector3.Distance(transform.position, PosicionPlayer.position);
        anima = GetComponent<Animator>();

        if (distPlayer < 8)
        {


            if (distPlayer < 2)
            {
                anima.SetBool("BeeMove", false);
                anima.SetBool("BeeAttack", true);
            }
            else
            {
                anima.SetBool("BeeAttack", false);
                anima.SetBool("BeeMove", true);
                navEnemigo.destination = player.transform.position;
            }
           
        }
        else
        {
            anima.SetBool("BeeAttack", false);
            anima.SetBool("BeeMove", false);
            grado = Random.Range(0, 360);
            angulo = Quaternion.Euler(0, grado, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 5f);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            //anima.SetBool("BeeMove", false);
        }

    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.tag == "muro")
        {
            
            grado = Random.Range(-45, 45);
            angulo = Quaternion.Euler(0, grado, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 5f);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }


    }


}
