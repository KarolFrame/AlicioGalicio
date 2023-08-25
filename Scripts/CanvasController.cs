using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    //REFERENCIA JUGADOR
    DatosJugador statsPlayer;

    //TEXTOS
    public Text textoMonedas;
    public Text textoLlaves;

    //IMAGENES
    public Image corazonUno, corazonDos, CorazonTres;


    void Start()
    {
        statsPlayer = FindObjectOfType<DatosJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        //MONEDAS
        if(statsPlayer.GetMonedas()<10)
            textoLlaves.text = "00" + statsPlayer.GetMonedas();
        else
            textoMonedas.text = "0" + statsPlayer.GetMonedas();
        //LLAVES
        if (statsPlayer.GetLlaves() < 10)
            textoLlaves.text = "00" + statsPlayer.GetLlaves();
        else
            textoLlaves.text = "0" + statsPlayer.GetLlaves();

        //VIDA
        if (statsPlayer.GetVida()==6)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 1;
            CorazonTres.fillAmount = 1;
        }
        if (statsPlayer.GetVida() == 5)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 1;
            CorazonTres.fillAmount = 0.5f;
        }
        if (statsPlayer.GetVida() == 4)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 1;
            CorazonTres.fillAmount = 0;
        }
        if (statsPlayer.GetVida() == 3)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 0.5f;
            CorazonTres.fillAmount = 0;
        }
        if (statsPlayer.GetVida() == 2)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 0;
            CorazonTres.fillAmount = 0;
        }
        if (statsPlayer.GetVida() == 1)
        {
            corazonUno.fillAmount = 0.5f;
            corazonDos.fillAmount = 0;
            CorazonTres.fillAmount = 0;
        }
        if (statsPlayer.GetVida() == 0)
        {
            corazonUno.fillAmount = 0;
            corazonDos.fillAmount = 0;
            CorazonTres.fillAmount = 0;
        }
    }
}
