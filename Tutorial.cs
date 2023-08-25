using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [TextArea(4,6)]public string[] dialogosTuto;
    int indexTuto = 0;

    Player jugador;
    GestionMenu menu;
    GenerarBomba bombasPlayer;
    UsarPocion pocionPlayer;

    float temporizador = 2;
    int a = 0;
    bool activarTuto = false;

    public GameObject canvas;
    public Text texto;

    public GameObject[] spritesTuto;

    bool horizontal = false, vertical = false, correr = false, atacar = false;

    int objetosRecogidos = 0;
    bool abreInventario = false;

    public GameObject controles;
    public Text controlesText;

    public Camera main, animaCam;

    Inventario inventario;
    public Animator animPlayer;

    //PARTICULAS
    public ParticleSystem polvoPies;
    ParticleSystem.EmissionModule emisionPolvoPies;

    void Start()
    {
        jugador = FindObjectOfType<Player>();
        canvas.SetActive(false);
        jugador.enabled = false;
        menu = FindObjectOfType<GestionMenu>();
        bombasPlayer = FindObjectOfType<GenerarBomba>();
        pocionPlayer = FindObjectOfType<UsarPocion>();

        main = Camera.main;

        controles.SetActive(false);

        inventario = FindObjectOfType<Inventario>();

        for (int i = 0; i < spritesTuto.Length; i++)
        {
            spritesTuto[i].SetActive(false);
        }

        emisionPolvoPies = polvoPies.emission;


        /*animaCam.enabled = false;
        main.enabled = false;
        animaCam.enabled = true;*/

    }

    void Update()
    {
        GestionTuto();

        if(!activarTuto && a==0)
        temporizador -= Time.deltaTime;

        if(temporizador<=0 && a==0)
        {
            activarTuto = true;
        }
        if(activarTuto)
        {
            canvas.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(MostrarDialogo());
            a++;
            activarTuto = false;
        }

        if(!inventario.GetMuestraMenu())
        {
            if(canvas.activeSelf)
            {
                if (Input.GetButtonDown("Menu"))
                    SiguienteTexto();
            }
        }

    }
    private IEnumerator MostrarDialogo()
    {
        texto.text = string.Empty;
        foreach (char ch in dialogosTuto[indexTuto])
        {
            texto.text += ch;
            yield return new WaitForSeconds(0.025f);
        }
    }
    public void SiguienteTexto()
    {
        StopAllCoroutines();
        canvas.SetActive(true);
        animPlayer.SetBool("mov", false);
        emisionPolvoPies.rateOverTime = 0;
        indexTuto++;
        StartCoroutine(MostrarDialogo());
    }
    void GestionTuto()
    {
        if(indexTuto == 4)
        {
            jugador.enabled = true;
            StopAllCoroutines();
            canvas.SetActive(false);
            controles.SetActive(true);
            controlesText.text = "Pulsa las flechas para moverte y mante el shift para correr.";

            
            if (Input.GetButtonDown("Correr"))
                correr = true;
            if (Input.GetAxis("Vertical") != 0)
                vertical = true;
            if (Input.GetAxis("Horizontal") != 0)
                horizontal = true;

            if(vertical && horizontal && correr)
            {
                controlesText.text = "Pulsa la c para atacar.";

                if (Input.GetButtonDown("Atacar"))
                    atacar = true;
            }
            if (horizontal && vertical && correr && atacar)
            {
                canvas.SetActive(true);
                controles.SetActive(false);
                jugador.enabled = false;
                SiguienteTexto();
            }
        }
        if(indexTuto ==6)
        {
            canvas.SetActive(false);
            for (int i = 0; i < spritesTuto.Length; i++)
            {
                spritesTuto[i].SetActive(true);
            }
            indexTuto++;
        }
        if(indexTuto == 7)
        {
            controles.SetActive(true);
            jugador.enabled = true;
            controlesText.text = "Recoge los items del suelo.";
            if (objetosRecogidos==3)
            {
                    canvas.SetActive(true);
                    controles.SetActive(false);
                    jugador.enabled = false;
                    SiguienteTexto();
            }
        }
        if(indexTuto == 9)
        {
            menu.IrPag(1);
        }
        if (indexTuto == 10)
        {
            jugador.enabled = true;
            StopAllCoroutines();
            canvas.SetActive(false);
            controles.SetActive(true);
            controlesText.text = "Pulsa el objeto que quieras equipar, luego pulsa la X para usarlo";

            if(bombasPlayer && Input.GetButtonDown("Hablar/Secundaria") || pocionPlayer && Input.GetButtonDown("Hablar/Secundaria"))
            {
                canvas.SetActive(true);
                controles.SetActive(false);
                jugador.enabled = false;
                SiguienteTexto();
            }
        }
        if(indexTuto == 12)
        {
            canvas.SetActive(false);
            jugador.enabled = true;
        }
        if(indexTuto == 13)
        {
            jugador.enabled = false;
        }
        if(indexTuto == 14)
        {
            canvas.SetActive(false);
            controles.SetActive(true);
            jugador.enabled = true;
            controlesText.text = "Acercate al barril y pulsa la V.";
            if(Input.GetButtonDown("Coger"))
            {
                controles.SetActive(false);
                jugador.enabled = false;
                SiguienteTexto();
            }
        }
        if(indexTuto == 16)
        {
            canvas.SetActive(false);
            jugador.enabled = true;
        }
        if(indexTuto ==17)
        {
            canvas.SetActive(true);
            jugador.enabled = false;
        }
        if(indexTuto == 18)
        {
            canvas.SetActive(false);
            jugador.enabled = true;
            controles.SetActive(true);
            controlesText.text = "Acercate al cañon y pulsa la c.";
            canon canonReference = FindObjectOfType<canon>();
            if (canonReference.GetUso())
            {
                controles.SetActive(false);
                jugador.enabled = true;
                SiguienteTexto();
            }
        }
        if(indexTuto == 19)
        {
            canvas.SetActive(false);
            jugador.enabled = true;
        }
    }
    public void SumarObjetoRecogido()
    {
        objetosRecogidos++;
    }
}
