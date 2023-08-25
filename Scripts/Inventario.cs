using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public GameObject menuRecortables, menu;
    public bool muestraMenu = false;

    private int allSlots = 0;
    private int allSlotsObjetos = 0;

    private int enabledSlots;

    public GameObject[] slot;
    public GameObject[] slotObjetos;

    public GameObject slotHolder;
    public GameObject slotHolderObjetos;

    public GameObject tutorial;

    SoundManager sound;

    //AL INICIAR
    private void Awake()
    {
        //Recortables
        slotHolder = GameObject.Find("PanelRecortablesHolder");
        slotHolder.SetActive(true);

        //Objetos
        slotHolderObjetos = GameObject.Find("PanelObjetosHolder");
        slotHolderObjetos.SetActive(true);

        sound = FindObjectOfType<SoundManager>();

        muestraMenu = false;

        //Asignar SLOTS recortables
        for (int i = 0; i < slot.Length; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        //Asignar SLOTS objetos
        for (int i = 0; i < slotObjetos.Length; i++)
        {
            slotObjetos[i] = slotHolderObjetos.transform.GetChild(i).gameObject;
            if(slotObjetos[i].GetComponent<Slot>().item == null)
            {
                slotObjetos[i].GetComponent<Slot>().empty = true;
            }
        }
    }
    void Start()
    {

        //slotHolder.SetActive(false);
        //slot = new GameObject[allSlots];
    }

    //CADA TICK
    void Update()
    {
        //MENU
        if(!tutorial.activeSelf)
        {
            if (Input.GetButtonDown("Menu"))
                muestraMenu = !muestraMenu;
            GestionMenu();
        }
    }

    //FUNCIONES
    public void GestionMenu()
	{
        //MENU RECORTABLES
        if (muestraMenu)
            menu.SetActive(true);
        else
            menu.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Item")
		{
            GameObject itemPickedUp = other.gameObject;
            Items item = itemPickedUp.GetComponent<Items>();

            //RECORTABLES
            if(item.type =="Recortable")
            {
                ComprobarSlotRecortables(other.gameObject, other.gameObject.GetComponent<Items>(), 0);

                sound.SeleccionAudio(10, 1);
            }
            //OBJETOS
            if (item.type == "Objeto")
            {

                ComprobarSlotObjetos(other.gameObject, other.gameObject.GetComponent<Items>(), 0);

                sound.SeleccionAudio(10, 1);
            }
        }
	}
    public void ComprobarSlotObjetos(GameObject itemPickedUp, Items item, int slotComprobandose)
    {
        bool buscando = true;

        if (buscando)
        {
            if (slotObjetos[slotComprobandose].GetComponent<Slot>().empty)
            {
                itemPickedUp.GetComponent<Items>().pickedUp = true;

                slotObjetos[slotComprobandose].GetComponent<Slot>().item = itemPickedUp;
                slotObjetos[slotComprobandose].GetComponent<Slot>().ID = item.ID;

                slotObjetos[slotComprobandose].GetComponent<Slot>().type = item.type;
                slotObjetos[slotComprobandose].GetComponent<Slot>().descripcion = item.descripcion;
                slotObjetos[slotComprobandose].GetComponent<Slot>().icon = item.icon;

                slotObjetos[slotComprobandose].GetComponent<Slot>().numeroObjeto++;

                //DESCATIVAR ICONO EN MAPA Y PONERLO EN MENU
                itemPickedUp.transform.parent = slotObjetos[slotComprobandose].transform;
                itemPickedUp.SetActive(false);

                slotObjetos[slotComprobandose].GetComponent<Slot>().UpdateSlot();

                //EL SLOT ESTA LLENO
                slotObjetos[slotComprobandose].GetComponent<Slot>().empty = false;
                //DEJAR DE BUSCAR
                buscando = false;
            }
            else
            {
                if (slotObjetos[slotComprobandose].GetComponent<Slot>().descripcion == item.descripcion)
                {
                    slotObjetos[slotComprobandose].GetComponent<Slot>().numeroObjeto++;

                    //DESCATIVAR ICONO EN MAPA Y PONERLO EN MENU
                    itemPickedUp.transform.parent = slotObjetos[slotComprobandose].transform;
                    itemPickedUp.SetActive(false);

                    slotObjetos[slotComprobandose].GetComponent<Slot>().UpdateSlot();

                    //EL SLOT ESTA LLENO
                    slotObjetos[slotComprobandose].GetComponent<Slot>().empty = false;
                    //DEJAR DE BUSCAR
                    buscando = false;
                }
                else
                {
                    slotComprobandose++;
                    ComprobarSlotObjetos(itemPickedUp, item, slotComprobandose);
                }
            }
        }
    }

    public void ComprobarSlotRecortables(GameObject itemPickedUp, Items item, int slotComprobandose)
    {
        bool buscando = true;

        if (buscando)
        {
            if (slot[slotComprobandose].GetComponent<Slot>().empty)
            {
                itemPickedUp.GetComponent<Items>().pickedUp = true;

                slot[slotComprobandose].GetComponent<Slot>().item = itemPickedUp;
                slot[slotComprobandose].GetComponent<Slot>().ID = item.ID;

                slot[slotComprobandose].GetComponent<Slot>().type = item.type;
                slot[slotComprobandose].GetComponent<Slot>().descripcion = item.descripcion;
                slot[slotComprobandose].GetComponent<Slot>().icon = item.icon;

                slot[slotComprobandose].GetComponent<Slot>().numeroObjeto++;

                //DESCATIVAR ICONO EN MAPA Y PONERLO EN MENU
                itemPickedUp.transform.parent = slot[slotComprobandose].transform;
                itemPickedUp.SetActive(false);

                slot[slotComprobandose].GetComponent<Slot>().UpdateSlot();

                //EL SLOT ESTA LLENO
                slot[slotComprobandose].GetComponent<Slot>().empty = false;
                //DEJAR DE BUSCAR
                buscando = false;
            }
            else
            {
                if (slot[slotComprobandose].GetComponent<Slot>().descripcion == item.descripcion)
                {
                    slot[slotComprobandose].GetComponent<Slot>().numeroObjeto++;

                    //DESCATIVAR ICONO EN MAPA Y PONERLO EN MENU
                    itemPickedUp.transform.parent = slot[slotComprobandose].transform;
                    itemPickedUp.SetActive(false);

                    slot[slotComprobandose].GetComponent<Slot>().UpdateSlot();

                    //EL SLOT ESTA LLENO
                    slot[slotComprobandose].GetComponent<Slot>().empty = false;
                    //DEJAR DE BUSCAR
                    buscando = false;
                }
                else
                {
                    slotComprobandose++;
                    ComprobarSlotRecortables(itemPickedUp, item, slotComprobandose);
                }
            }
        }
    }

    
    //GET
    public bool GetMuestraMenu()
    {
        return muestraMenu;
    }
    //SET
    public void SetMuestraInventario(bool si)
    {
        muestraMenu = si;
    }
}
