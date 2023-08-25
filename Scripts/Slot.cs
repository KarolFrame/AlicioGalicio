using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerClickHandler
{
	public GameObject item;
	public int ID;
	public string type;
	public string descripcion;

	public bool empty = true;
	public Sprite icon;

	[HideInInspector]
	public bool pickedUp;


	public Transform slotIconGameObject;
	Image icono;

	public int numeroObjeto;
	Text textNumero;

	DatosJugador statsPlayer;
	

    private void Start()
    {
		slotIconGameObject = transform.GetChild(0);
		empty = true;
		textNumero = slotIconGameObject.transform.GetChild(0).GetComponent<Text>();
		textNumero.text = " ";
		statsPlayer = FindObjectOfType<DatosJugador>();

		icono = slotIconGameObject.GetComponent<Image>();
		if(icono)
        {
			if(icono.sprite == null)
            {
				icono.color = new Color(1, 1, 1, 0);
            }
        }

	}
    public void UpdateSlot()
    {
		slotIconGameObject.GetComponent<Image>().sprite = icon;
		icono.color = new Color(1, 1, 1, 1);
		if (numeroObjeto > 0)
			textNumero.text = "X" + numeroObjeto;

		//SETEAR STATS IMPORTANTES
		if(descripcion == "Bomba")
        {
			statsPlayer.SetBombas(numeroObjeto);
        }
		if (descripcion == "Llave")
		{
			statsPlayer.SetLlaves(numeroObjeto);
		}
		if(descripcion == "Tirachinas")
        {
			statsPlayer.SetTirachinas(numeroObjeto);
        }
		if (descripcion == "Pocion")
		{
			statsPlayer.SetPociones(numeroObjeto);
		}
	}
	public void UpdateNumeroObjeto(string tipo,int nuevonum)
    {
		if(descripcion == tipo)
        {
			numeroObjeto = nuevonum;
			if (numeroObjeto > 0)
				textNumero.text = "X" + numeroObjeto;
			if (numeroObjeto == 0)
			{
				VaciarSlot();
			}
		}
    }
	void VaciarSlot()
    {
		numeroObjeto = 0;
		textNumero.text = "X0";
	}

	public void OnPointerClick(PointerEventData pointerEventData)
    {
		item.GetComponent<Items>().UsarItem();
    }
}
