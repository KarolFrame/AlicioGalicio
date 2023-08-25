using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaDialogoManager : MonoBehaviour
{
    public string[] textos;
    public TMPro.TextMeshProUGUI textTienda;
    public TMPro.TextMeshProUGUI textCompra;
    AnimatorManagerTienda anim;
    public GameObject[] panelesDialogo;

    DatosJugador player;

    int objetoQueCompras;

    Slot[] slots;

    //DIALOGOS SIMPLES
    void Awake()
    {
        textTienda.text = textos[0];
        anim = FindObjectOfType<AnimatorManagerTienda>();
        player = FindObjectOfType<DatosJugador>();
        slots = FindObjectsOfType<Slot>();
    }
    private void Start()
    {
        panelesDialogo[0].gameObject.SetActive(true);
        panelesDialogo[1].gameObject.SetActive(false);
    }
    public void SeleccionarDialogo(int i)
    {
        textTienda.text = textos[i];
        anim.ChiquetaHabla();
    }
    //
    public void ComprasPocion()
    {
        if(player.GetMonedas()< 20)//No teiene dinero suficiente
        {
            textTienda.text = textos[5];
            anim.ChiquetaHabla();
        }
        else //Tiene dinero
        {
            objetoQueCompras = 0; //Pociones

            panelesDialogo[0].gameObject.SetActive(false);
            panelesDialogo[1].gameObject.SetActive(true);

            textCompra.text = "¿Quieres esto? Son 20 monedas";
            anim.ChiquetaHabla();
        }
    }
    public void ComprasBomba()
    {
        if (player.GetMonedas() < 30)//No teiene dinero suficiente
        {
            textTienda.text = textos[5];
            anim.ChiquetaHabla();
        }
        else //Tiene dinero
        {
            objetoQueCompras = 1; //Bombas

            panelesDialogo[0].gameObject.SetActive(false);
            panelesDialogo[1].gameObject.SetActive(true);

            textCompra.text = "¿Quieres esto? Son 30 monedas";
            anim.ChiquetaHabla();
        }
    }
    public void ComprasTirachinas()
    {
        if (player.GetMonedas() < 40)//No teiene dinero suficiente
        {
            textTienda.text = textos[5];
            anim.ChiquetaHabla();
        }
        else //Tiene dinero
        {
            objetoQueCompras = 2; //Tirachinas

            panelesDialogo[0].gameObject.SetActive(false);
            panelesDialogo[1].gameObject.SetActive(true);

            textCompra.text = "¿Quieres esto? Son 40 monedas";
            anim.ChiquetaHabla();
        }
    }
    public void SICompras()
    {
        if(objetoQueCompras == 0) //Pociones
        {
            //SUMAR POCIONES
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateNumeroObjeto("Pocion", player.GetPociones() + 1);
            }
            player.SetPociones(player.GetPociones() + 1);

            //RESTAR MONEDAS
            player.SetMonedas(player.GetMonedas() - 20);

            HasComprado();
        }
        if (objetoQueCompras == 1) //Bombas
        {
            //SUMAR BOMBAS
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateNumeroObjeto("Bomba", player.GetBombas() + 5);
            }
            player.SetBombas(player.GetBombas() + 5);

            //RESTAR MONEDAS
            player.SetMonedas(player.GetMonedas() - 30);

            HasComprado();
        }
        if (objetoQueCompras == 2) //Tirachinas
        {
            //SUMAR TIRACHINAS
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateNumeroObjeto("Tirachinas", player.GetTirachinas() + 10);
            }
            player.SetTirachinas(player.GetTirachinas() + 10);

            //RESTAR MONEDAS
            player.SetMonedas(player.GetMonedas() - 40);

            HasComprado();
        }
    }
    public void NOCompras()
    {
        panelesDialogo[0].gameObject.SetActive(true);
        panelesDialogo[1].gameObject.SetActive(false);

        textTienda.text = textos[4];
        anim.ChiquetaHabla();
    }

    void HasComprado()
    {
        panelesDialogo[0].gameObject.SetActive(true);
        panelesDialogo[1].gameObject.SetActive(false);

        textTienda.text = textos[6];
        anim.ChiquetaLeCompran();
    }

}
