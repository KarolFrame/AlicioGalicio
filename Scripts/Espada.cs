using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Espada : MonoBehaviour
{
    DatosJugador statsPlayer;
    bool activarTempo = false;
    float tempo;
    Animator animPlayer;

    DatosEnemigo enemigo;
    NavMeshAgent enemigaNav;
    Rigidbody enemigoRB;

    Collider trigger;
    bool activarTempoTrigger = false;
    float tempoTrigger;

    bool retorcesoActivo = false;

    SoundManager sound;


    private void Awake()
    {
        statsPlayer = FindObjectOfType<DatosJugador>();
        animPlayer = GameObject.Find("Alicio").GetComponent<Animator>();
        trigger = GetComponent<Collider>();

        sound = FindObjectOfType<SoundManager>();

        trigger.enabled = false;
        tempoTrigger = 0.5f;
        tempo = 0.1f; 
    }

    // Update is called once per frame
    void Update()
    {
        if (activarTempo)
            tempo -= Time.deltaTime;
        if (tempo <= 0)
        {
            if (enemigo != null && enemigaNav != null && enemigoRB != null)
            {
                enemigoRB.isKinematic = true;
                enemigaNav.enabled = true;
                activarTempo = false;
                retorcesoActivo = false;
            }
        }

        //RETROCESO
        if(retorcesoActivo)
        {
            if(enemigo != null)
            {
                enemigo.transform.Translate(-Vector3.forward * 30* Time.deltaTime);
            }
        }

        if (Input.GetButtonDown("Atacar"))
        {
            trigger.enabled = true;
            //animPlayer.SetBool("Ataca", true);
            animPlayer.SetTrigger("Atacar");
            
            tempoTrigger = 0.5f;

            sound.SeleccionAudio(0,1);

            activarTempoTrigger = true;
        }
        if (activarTempoTrigger)
            tempoTrigger -= Time.deltaTime;
        if(tempoTrigger<=0)
        {
            trigger.enabled = false;
            activarTempoTrigger = false;
            //animPlayer.SetBool("Ataca", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemigo")
        {
            enemigo = other.GetComponent<DatosEnemigo>();
            enemigaNav = other.GetComponent<NavMeshAgent>();
            enemigoRB = other.GetComponent<Rigidbody>();

            if (enemigo != null && enemigaNav != null && enemigoRB != null)
            {
                enemigo.SetVida(
                    enemigo.GetVida() - statsPlayer.GetDanoEspada()
                    );
                sound.SeleccionAudio(13, 1);
                enemigaNav.enabled = false;
                enemigoRB.isKinematic = false;
                //enemigoRB.AddForce(-other.transform.forward * 4, ForceMode.Impulse);
                tempo = 0.1f;
                retorcesoActivo = true;
                activarTempo = true;
            }
        }
    }
}
