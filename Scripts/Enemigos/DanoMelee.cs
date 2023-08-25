using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DanoMelee : MonoBehaviour
{
    bool llegaJugador = false;
    DatosJugador statsPlayer;
    int danoEnemigo;
    int cadacuantopega;
    float cooldown;
    Animator animEnemigo;
    Transform tr;

    bool activarRetroceso = false;
    float tempoRetroceso;

    SoundManager sound;

    void Awake()
    {
        tr = transform;
        animEnemigo = GetComponentInChildren<Animator>();
        statsPlayer = FindObjectOfType<DatosJugador>();
        llegaJugador = false;
        danoEnemigo = 1;
        cooldown = 0.5f;
        cadacuantopega = 1;
        sound = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if(Vector3.Distance(statsPlayer.transform.position, tr.position)<=1f)
            llegaJugador = true;
        else
            llegaJugador = false;
        if (llegaJugador)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <=0)
            {
                animEnemigo.SetTrigger("Ataca");
                statsPlayer.SetVida(statsPlayer.GetVida() - danoEnemigo);
                //RETROCESO DEL JUGADOR
                tempoRetroceso = 0.1f;
                activarRetroceso = true;
                statsPlayer.GetComponent<NavMeshAgent>().enabled = false;
                statsPlayer.GetComponent<Rigidbody>().isKinematic = false;
                //SONIDO
                sound.SeleccionAudio(14, 1);
                //Te pega en X segundos
                cooldown = cadacuantopega;
            }
        }
        if(activarRetroceso)
        {
            tempoRetroceso -= Time.deltaTime;

            statsPlayer.transform.Translate(-Vector3.forward * 30 * Time.deltaTime);
        }
        if(tempoRetroceso<=0)
        {
            activarRetroceso = false;
            statsPlayer.GetComponent<NavMeshAgent>().enabled = true;
            statsPlayer.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
