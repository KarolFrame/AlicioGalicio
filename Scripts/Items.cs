using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
	public int ID;
	public string type;
	public string descripcion;
	public Sprite icon;

	[HideInInspector]
	public bool pickedUp;

	[HideInInspector]
	public bool equipped = false;
	PonerRecortables ponerRecortables;
    SlotsPlayer[] manos;
    Inventario inventario;

    CursorManager cursorManager;

    private void Awake()
    {
		ponerRecortables = FindObjectOfType<PonerRecortables>();
        inventario = FindObjectOfType<Inventario>();
        manos = FindObjectsOfType<SlotsPlayer>();
        cursorManager = FindObjectOfType<CursorManager>();
    }
    public void UsarItem()
    {
		if(type == "Recortable")
        {
			ponerRecortables.SetItemRecortable(this.gameObject);
            inventario.SetMuestraInventario(false);
            cursorManager.SetCursorRecortable(icon);
        }
		if(type == "Objeto")
        {
			if(ID == 0) //ESPADAS
            {
                for (int i = 0; i < manos.Length; i++)
                {
                    manos[i].RellenarManoPrincipal(ID, type, descripcion,icon);
                }
            }
			if(ID == 1) //SECUNDARIA
            {
                for (int i = 0; i < manos.Length; i++)
                {
                    manos[i].RellenarManoSecundaria(ID, type, descripcion, icon);
                }
            }
			if(ID == 2) //COLECCIONABLES
            {

            }
        }
    }
}
