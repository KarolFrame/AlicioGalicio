using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHabla : MonoBehaviour
{
    public string dialogo, nombre;
    public GameObject uI;
    public Animator anim;
    void Awake()
    {
        uI.SetActive(false);
    }

    //PASAR DIAOLOGO AL PANEL
    public string GetDialogo()
    {
        return dialogo;
    }
    public string GetNombre()
    {
        return nombre;
    }
    public GameObject GetUI()
    {
        return uI;
    }
    public Animator GetAnim()
    {
        return anim;
    }

    //ACTIVAR Y DESACTIVAR LA UI
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            uI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            uI.SetActive(false);
            if (anim != null)
                anim.SetBool("si", false);
        }
    }
}
