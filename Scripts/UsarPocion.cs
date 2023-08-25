using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarPocion : MonoBehaviour
{
    bool conNPC = false, conTienda = false, conLlave = false;

    DatosJugador stats;
    Slot[] slots;

    SoundManager sound;

    private void Awake()
    {
        stats = GetComponent<DatosJugador>();
        slots = FindObjectsOfType<Slot>();
        sound = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Hablar/Secundaria") && !conNPC &&!conLlave && !conTienda && stats.GetPociones() > 0)
        {

            sound.SeleccionAudio(23,1);

            stats.SetVida(stats.GetVida() + 4);
            if(stats.GetVida()>6)
                stats.SetVida(6);
            //RESTAR POCION USADA
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateNumeroObjeto("Pocion", stats.GetPociones() - 1);
            }
            stats.SetPociones(stats.GetPociones() - 1);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "NPCHabla")
        {
            conNPC = true;
        }
        if (other.name == "NPCMision")
        {
            conNPC = true;
        }
        if (other.gameObject.tag == "Tienda")
        {
            conTienda = true;
        }
        if(other.gameObject.tag == "Llave")
        {
            conLlave = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "NPCHabla")
        {
            conNPC = false;
        }
        if (other.name == "NPCMision")
        {
            conNPC = false;
        }
        if (other.gameObject.tag == "Tienda")
        {
            conTienda = false;
        }
        if (other.gameObject.tag == "Llave")
        {
            conLlave = false;
        }
    }
}
