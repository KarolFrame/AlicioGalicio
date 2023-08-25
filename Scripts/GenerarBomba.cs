using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBomba : MonoBehaviour
{
    public GameObject prefabBomba;
    public Transform generadorBombas;
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
        if (Input.GetButtonDown("Hablar/Secundaria") && !conNPC && !conLlave && !conTienda && stats.GetBombas() > 0)
        {
            Instantiate(prefabBomba, generadorBombas.position, generadorBombas.rotation);

            sound.SeleccionAudio(1,1);
            sound.SeleccionAudio(21, 1);

            //RESTAR BOMBA USADA
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateNumeroObjeto("Bomba", stats.GetBombas()-1);
            }
            stats.SetBombas(stats.GetBombas() - 1);

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
        if(other.gameObject.tag == "Tienda")
        {
            conTienda = true;
        }
        if (other.gameObject.tag == "Llave")
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
        if(other.gameObject.tag == "Tienda")
        {
            conTienda = false;
        }
        if (other.gameObject.tag == "Llave")
        {
            conLlave = false;
        }
    }
}
