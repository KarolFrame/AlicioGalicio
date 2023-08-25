using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMision : MonoBehaviour
{
    enum EstadoMision {noMision, misionSigue, misionEnEspera}
    EstadoMision estadoMision;
    int index = 0;
    public string[] dialogo;
    public string nombre;
    public GameObject uI;
    Animator anim;
    public Animator animMalla;
    void Awake()
    {
        anim = GetComponent<Animator>();
        uI.SetActive(false);
        estadoMision = EstadoMision.noMision;
        //animMalla.SetBool("mov", false);
    }
    private void Update()
    {
        if (estadoMision == EstadoMision.noMision)
            animMalla.SetBool("mov", false);
    }

    //PASAR DIAOLOGO AL PANEL
    public string GetDialogo()
    {
        return dialogo[index];
    }
    public string GetNombre()
    {
        return nombre;
    }
    public GameObject GetUI()
    {
        return uI;
    }
    public void BtnSI()
    {
        index = 1;
        anim.SetBool("Sigue", true);
        estadoMision = EstadoMision.misionSigue;
    }
    public void BtnNO()
    {
        index = 2;
    }

    //ACTIVAR Y DESACTIVAR LA UI
    private void OnTriggerEnter(Collider other)
    {
        if(estadoMision == EstadoMision.noMision)
        {
            if (other.name == "Player")
            {
                uI.SetActive(true);
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (estadoMision == EstadoMision.noMision)
        {
            if (other.name == "Player")
        {
            uI.SetActive(false);
        }
        }
        index = 0;
    }
}
