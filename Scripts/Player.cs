using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //COMPONENTES
    NavMeshAgent agent;
    Rigidbody rB;
    Transform tr;
    public Animator animPlayer;
    //CAMARA
    Camera cameraMain;

    //PARTICULAS
    public ParticleSystem polvoPies;
    ParticleSystem.EmissionModule emisionPolvoPies;

    //TIENDA
    Tienda tienda;

    Inventario inventario;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rB = GetComponent<Rigidbody>();
        
        tienda = FindObjectOfType<Tienda>();
        inventario = FindObjectOfType<Inventario>();

        //animPlayer = GetComponent<Animator>();
    }
    void Start()
    {
        tr = transform;
        cameraMain = Camera.main;

        emisionPolvoPies = polvoPies.emission;
        emisionPolvoPies.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraMain.enabled)
        {
            if(!tienda.GetActivamosTienda())
            {
                if(!inventario.GetMuestraMenu())
                {
                    //MOVIMIENTO DEL PERSONAJE
                    MovimientoPersonaje();
                    //CORRER
                    if (Input.GetButton("Correr"))
                        agent.speed = 12;
                    else
                        agent.speed = 5.5f;

                    CheckPolvoPies();
                    Animaciones();
                }
            }
        }
        
    }

    private void CheckPolvoPies()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            emisionPolvoPies.rateOverTime = 25;
        else
            emisionPolvoPies.rateOverTime = 0;
    }
    void Animaciones()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            animPlayer.SetBool("mov", false);
        }
            
        else
        {
            animPlayer.SetBool("mov", true);

        }
            
    }

    void MovimientoPersonaje()
	{
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical);
        Vector3 destino = tr.position + movement;
        if(agent.enabled)
        agent.destination = destino;
    }

    //SET
    public void SetAnimator(GameObject Alicio)
    {
        animPlayer = Alicio.GetComponent<Animator>();
    }
}
