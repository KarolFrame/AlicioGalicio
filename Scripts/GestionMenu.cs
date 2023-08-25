using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMenu : MonoBehaviour
{
    Inventario invetario;
    int pagina = 0;
    GameObject pag0, pag1;
    public Animator anim;

    Player jugador;
    GenerarBomba bombasPlayer;
    UsarPocion pocionPlayer;
    private void Awake()
    {
        invetario = GetComponent<Inventario>();
        pag0 = GameObject.Find("PAG0");
        pag1 = GameObject.Find("PAG1");
        pagina = 0;

    }

    void Update()
    {
        if(invetario.GetMuestraMenu())
        {

            if(pagina == 0)
            {
                //PAGINAS
                pag0.SetActive(true);
                pag1.SetActive(false);
                //CAMBIAR PAGINA
                if(Input.GetAxis("Horizontal")>0)
                {
                    pagina = 1;
                }
            }
            if(pagina == 1)
            {
                //PAGINAS
                pag0.SetActive(false);
                pag1.SetActive(true);
                //CAMBIAR PAGINA
                if (Input.GetAxis("Horizontal") < 0)
                {
                    pagina = 0;
                }
            }
        }
    }
    public void IrPag(int pag)
    {
        pagina = pag;
        anim.SetInteger("pag", pag);
    }
}
