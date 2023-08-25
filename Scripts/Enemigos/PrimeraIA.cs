using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PrimeraIA : MonoBehaviour
{
    //ESTADOS
    enum Estado {patrulla, detectaJugador}
    Estado estado = Estado.patrulla;

    //VARIBALES PROPIAS
    NavMeshAgent agent;
    Transform tr;
    DatosEnemigo stats;
    GeneradorDeMonedas generarMonedas;

    float targetHorizontal, targetVertical;
    float temporizadorCambio = 5;

    //ANIMACIONES
    Animator animEnemigo;
    SpriteRenderer srSprite;

    //JUGADOR
    Player jugador;

    //SONIDO
    SoundManager sound;
    void Start()
    {
        tr = transform;
        agent = GetComponent<NavMeshAgent>();
        animEnemigo = GetComponentInChildren<Animator>();
        srSprite = GetComponentInChildren<SpriteRenderer>();
        jugador = FindObjectOfType<Player>();
        stats = GetComponent<DatosEnemigo>();
        generarMonedas = GetComponent<GeneradorDeMonedas>();
        sound = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //MUERTE
        if (stats.GetVida() == 0)
        {
            generarMonedas.GenerarMoneda();
            sound.SeleccionAudio(15, 1);
            Destroy(gameObject);
        }
            

        //CAMBIO DE TARGET
        temporizadorCambio -= Time.deltaTime;
        if(temporizadorCambio <=0 && temporizadorCambio > -5)
        {
            targetHorizontal = 0;
            targetVertical = 0;

        }
        if(temporizadorCambio <= -5)
        {
            targetHorizontal = Random.Range(-1f, 1f);
            targetVertical = Random.Range(-1f, 1f);
            temporizadorCambio = 5;

        }
        //MOVIMIENTO DE PATRULLA
        if (estado == Estado.patrulla)
        {
            float inputHorizontal = targetHorizontal;
            float inputVertical = targetVertical;

            Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical);
            Vector3 destino = tr.position + movement;
            if(agent.enabled)
            agent.destination = destino;

            if( targetHorizontal == 0 && targetVertical ==0)
            {
                //Animaciones
                animEnemigo.SetBool("enMov", false);
                animEnemigo.SetBool("veAlicio", false);
            }
            else
            {
                //Animaciones
                animEnemigo.SetBool("enMov", true);
                animEnemigo.SetBool("veAlicio", false);
            }
            //CAMBIO
            if(Vector3.Distance(tr.position, jugador.transform.position)<=6)
            {
                estado = Estado.detectaJugador;
            }
        }
        //SE MUEVE HACIA EL JUGADOR
        else
        {
            if(agent.enabled)
            {
                agent.destination = jugador.transform.position;
                //Animaciones
                animEnemigo.SetBool("veAlicio", true);
                animEnemigo.SetBool("enMov", true);
            }
            //CAMBIO
            if (Vector3.Distance(tr.position, jugador.transform.position) >= 6)
            {
                estado = Estado.patrulla;
            }

        }

        if(jugador.transform.position.x < tr.position.x)
            srSprite.flipX = true;
        else
            srSprite.flipX = false;


    }
}
