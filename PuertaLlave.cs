using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLlave : MonoBehaviour
{
    bool puedeAbrir = false;

    bool activamosUI = false;
    public GameObject ui;

    public Puerta puerta;

    DatosJugador stats;

    Slot[] slots;

    private void Awake()
    {
        stats = FindObjectOfType<DatosJugador>();
        slots = FindObjectsOfType<Slot>();
        GestionarUI();
    }
    void Update()
    {
        if (Input.GetButtonDown("Hablar/Secundaria") && puedeAbrir && stats.GetLlaves()>0)
        {
            puerta.SetSeAbre(true);
            //RESTAR LLAVE USADA

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateNumeroObjeto("Llave", stats.GetLlaves() - 1);
            }
            stats.SetLlaves(stats.GetLlaves() - 1);

        }
    }
    void GestionarUI()
    {
        if (activamosUI)
            ui.SetActive(true);
        else
            ui.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            puedeAbrir = true;
            activamosUI = true;
            GestionarUI();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            puedeAbrir = false;
            activamosUI = false;
            GestionarUI();
        }

    }
    public bool EnPuerta()
    {
        return puedeAbrir;
    }
}
