using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    //UI LIGADA
    public GameObject uI;
    //COMPONENTES
    Animator anim;

    //
    bool jugadorEstaEnTrigger;
    //SU PUERTA 
    public Puerta puerta;
    //SONIDO
    SoundManager sound;
    void Awake()
    {
        anim = GetComponent<Animator>();
        jugadorEstaEnTrigger = false;
        uI.SetActive(false);
        sound = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador esta en el trigger
        if (jugadorEstaEnTrigger)
        {
            //Si pulsa el boton de interactuar, en este caso el espacio
            if (Input.GetButtonDown("Atacar"))
            {
                //Si la palanca esta activa
                if (anim.GetBool("ActivarPalanca"))
                {
                    //Se desactiva
                    anim.SetBool("ActivarPalanca", false);
                    puerta.SetSeAbre(anim.GetBool("ActivarPalanca"));
                    sound.SeleccionAudio(18, 1);
                }
                //Si la palanca esta desactivada
                else
                {
                    //Se activa
                    anim.SetBool("ActivarPalanca", true);
                    puerta.SetSeAbre(anim.GetBool("ActivarPalanca"));
                    sound.SeleccionAudio(17, 1);
                }
                //Desactivasmo la UI
                uI.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador entra ne el trigger
        if (other.gameObject.tag == "Player")
        {
            //Actibamos el bool de que el jugador esta en trigger
            jugadorEstaEnTrigger = true;
            //Activamos la UI
            uI.SetActive(true);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        //Si el jugador sale del trigger
        if (other.gameObject.tag == "Player")
        {
            //Desactivamos el bool del jugador en area
            jugadorEstaEnTrigger = false;
            //Desactivamos la UI
            uI.SetActive(false);
        }
            
    }

}
