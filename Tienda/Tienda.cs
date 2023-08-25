using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    GameObject canvasTienda;
    public GameObject ui;

    bool activamosUI = false, activamosTienda = false;
    private void Awake()
    {
        canvasTienda = GameObject.Find("CanvasTienda");
    }
    void Start()
    {
        canvasTienda.gameObject.SetActive(false);
        GestionarUI();
        GestionarTienda();

    }

    // Update is called once per frame
    void Update()
    {
        if(activamosUI)
        {
            if(Input.GetButtonDown("Hablar/Secundaria"))
            {
                activamosTienda = true;
                GestionarTienda();
            }
        }
        if(activamosTienda)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                activamosTienda = false;
                GestionarTienda();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        activamosUI = true;
        GestionarUI();
    }
    private void OnTriggerExit(Collider other)
    {
        activamosUI = false;
        GestionarUI();
    }
    void GestionarUI()
    {
        if (activamosUI)
            ui.gameObject.SetActive(true);
        else
            ui.gameObject.SetActive(false);
    }
    void GestionarTienda()
    {
        if(activamosTienda)
            canvasTienda.gameObject.SetActive(true);
        else
            canvasTienda.gameObject.SetActive(false);
    }

    public bool GetActivamosTienda()
    {
        return activamosTienda;
    }
}
