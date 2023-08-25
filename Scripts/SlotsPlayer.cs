using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotsPlayer : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string type;
    public string descripcion;

    public bool empty = true;
    public Sprite icon;
    public int mano;

    public Transform slotIconGameObject;
    Image icono;

    public Image imageHUD;


    GenerarBomba playerBomba;
    Tirachinas playerTirachinas;
    UsarPocion playerPocion;
    DatosJugador datosPlayer;


    private void Awake()
    {
        slotIconGameObject = transform.GetChild(0);
        icono = slotIconGameObject.GetComponent<Image>();

        if (icono)
        {
            if (icono.sprite == null)
            {
                icono.color = new Color(1, 1, 1, 0);
            }
        }


        playerBomba = FindObjectOfType<GenerarBomba>();
        playerTirachinas = FindObjectOfType<Tirachinas>();
        playerPocion = FindObjectOfType<UsarPocion>();
        datosPlayer = FindObjectOfType<DatosJugador>();

        descripcion = null;

        if(mano == 1)
        {
            if (descripcion == null)
            {
                playerBomba.enabled = false;
                playerTirachinas.enabled = false;
                playerPocion.enabled = false;
            }
        }
    }
    void Update()
    {
        
    }

    public void RellenarManoPrincipal(int nuevaID, string nuevotype, string nuevaDescription, Sprite nuevoIcon)
    {
        icono.color = new Color(1, 1, 1, 1);

        if (mano == 0)
        {
            //CAMBIAR INTERFAZ
            ID = nuevaID;
            type = nuevotype;
            descripcion = nuevaDescription;
            icon = nuevoIcon;

            slotIconGameObject.GetComponent<Image>().sprite = icon;
            //CAMBIAR STATS
            if(descripcion == "Espada Inicial")
            {
                datosPlayer.SetDanoEspada(1);
            }
        }
    }
    public void RellenarManoSecundaria(int nuevaID, string nuevotype, string nuevaDescription, Sprite nuevoIcon)
    {
        icono.color = new Color(1, 1, 1, 1);

        if (mano == 1)
        {
            //CAMBIAR INTERFAZ
            ID = nuevaID;
            type = nuevotype;
            descripcion = nuevaDescription;
            icon = nuevoIcon;

            slotIconGameObject.GetComponent<Image>().sprite = icon;
            //CAMBIAR ACCION SECUNDARIA
            //Bomba
            if (descripcion == "Bomba")
            {
                playerBomba.enabled = true;
                playerTirachinas.enabled = false;
                playerPocion.enabled = false;

                imageHUD.sprite = icon;

            }
            //Tirachinas
            if (descripcion == "Tirachinas")
            {
                playerBomba.enabled = false;
                playerTirachinas.enabled = true;
                playerPocion.enabled = false;

                imageHUD.sprite = icon;
            }
            //Pocion
            if (descripcion == "Pocion")
            {

                playerBomba.enabled = false;
                playerTirachinas.enabled = false;
                playerPocion.enabled = true;

                imageHUD.sprite = icon;

            }
        }
    }
}
