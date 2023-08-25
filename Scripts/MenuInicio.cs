using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    GameObject jugador;
    DatosJugador stats;
    Canvas[] canvas;
    void Start()
    {
        jugador = GameObject.Find("Alicio");
        canvas = FindObjectsOfType<Canvas>();
        for (int i = 0; i < canvas.Length; i++)
        {
            if(canvas[i].gameObject.name != "CanvasMenuInicio")
            {
                canvas[i].enabled = false;
            }
        }
        if(jugador!=null)
        {
            print("Detecta jugador");
            jugador.SetActive(true);
            stats = jugador.GetComponent<DatosJugador>();
        }
        if (stats != null)
            stats.LoadData();
        
    }

    void Update()
    {
        
    }
}
