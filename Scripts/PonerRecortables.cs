using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PonerRecortables : MonoBehaviour
{
    Items itemActivoRecortable;

    CursorManager cursorManager;

    SoundManager sound;
    private void Awake()
    {
        cursorManager = FindObjectOfType<CursorManager>();
        sound = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        //CLICK DE OBJETOS
        if (Input.GetButtonDown("Fire1"))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //Si el rayo choca con algo, se procesa el choque
            if (Physics.Raycast(rayo, out hit))
            {
                if (hit.collider.GetComponent<Recortable>() != null)
                {
                    //Creamos una varibale string y le damos el nombre que tenga el recortable
                    string nombreRecortable = hit.collider.GetComponent<Recortable>().GetRecortable();

                    //si esta variable creada y la descripcion del item coninciden el recortable se activara
                    if(nombreRecortable == itemActivoRecortable.descripcion)
                    {
                        sound.SeleccionAudio(4,1);

                        Animator animCollider;
                        animCollider = hit.collider.GetComponent<Animator>();
                        animCollider.SetBool("ActivaElPuente", true);
                        cursorManager.CursosPorDefecto();
                    }
                }
            }
        }
    }

    //SET
    public void SetItemRecortable(GameObject item)
    {
        itemActivoRecortable = item.GetComponent<Items>();
    }
}
