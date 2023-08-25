using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePresion : MonoBehaviour
{
    //COMPONENTES
    Animator anim;
    //SU PUERTA 
    public Puerta puerta;
    //NUMERO de objetos que hay sobre la placa de presion
    int objetosSobrePlaca;
    //SONIDO
    SoundManager sound;
    private void Awake()
    {
        //INICIALIZACION DE VARIABLE
        anim = GetComponent<Animator>();
        objetosSobrePlaca = 0;
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Activar la animcaión de la placa de presion
        anim.SetBool("HacenPresion", true);
        //Activar el bool que hace que se active la puerta
        puerta.SetSeAbre(anim.GetBool("HacenPresion"));
        //Sumar 1 al numero de objetos que hay sobre la palanca
        objetosSobrePlaca++;
        //Suena
        if(objetosSobrePlaca == 1)
            sound.SeleccionAudio(19,1);
    }
    private void OnTriggerExit(Collider other)
    {
        //Restar 1 al numero de objetos que hay sobre la placa
        objetosSobrePlaca--;
        //SI NO HAY NADA SOBRE LA PLACA
        if(objetosSobrePlaca <=0)
        {
            //Animacion de que sube la placa
            anim.SetBool("HacenPresion", false);
            //Desactivar puerta correspondiente
            puerta.SetSeAbre(anim.GetBool("HacenPresion"));
        }
            
    }
}
