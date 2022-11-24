using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class CodSpider : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PosicionPlayer;
    public float distPlayer;

    [SerializeField] private GameObject player;
    public NavMeshAgent navEnemigo;

    private float crono;
    public int evento;
    public Animator anima;
    private float grado = 0;
    private Quaternion angulo;

    private float tipoAtack;
    void Start()
    {

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
            if (distPlayer < 1)
            {
                tipoAtack = Random.Range(0, 3);
                

                switch (tipoAtack)
                {
                    case 0:
                        {
                            anima.SetBool("IsSpiderAttackR", true);
                            anima.SetBool("IsSpiderAttackL", false);
                            anima.SetBool("IsSpiderAttack", false);

                            break;
                        }
                    case 1:
                        {
                            anima.SetBool("IsSpiderAttackL", true);
                            anima.SetBool("IsSpiderAttackR", false);
                            anima.SetBool("IsSpiderAttack", false);
                            break;
                        }

                    case 2:
                        {
                            anima.SetBool("IsSpiderAttack", true);
                            anima.SetBool("IsSpiderAttackR", false);
                            anima.SetBool("IsSpiderAttackL", false);
                            break;
                        }                     
                }
            }
            else
            {
                anima.SetBool("IsSpiderWalk", false);
                anima.SetBool("IsSpiderAttackR", false);
                anima.SetBool("IsSpiderAttackL", false);
                anima.SetBool("IsSpiderAttack", false);
                anima.SetBool("IsSpiderRun", true);
                navEnemigo.destination = player.transform.position;
            }

        }
        else
        {
            anima.SetBool("IsSpiderAttack", false);
            anima.SetBool("IsSpiderRun", false);
            anima.SetBool("IsSpiderWalk", true);
            grado = Random.Range(0, 360);
            angulo = Quaternion.Euler(0, grado, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 5f);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
            
        }

    }


    void OnCollisionStay(Collision collision)
    {


        if (collision.transform.tag == "muro")
        {

            Debug.Log("HS");
            grado = Random.Range(-45, 45);
            angulo = Quaternion.Euler(0, grado, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 5f);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }


    }




}
