using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class canon : MonoBehaviour
{
    //OBJETOS NECESARIOS PARA EL CODIGO
    GameObject cabezaCanon;
    GameObject generadorBolas;
    public Camera camaraCanon;
    public Camera mainCamera;

    //BOLAS QUE DISPARA EL CANON Y LA FUERZA CON LA QUE SALEN ESTAS
    public GameObject bolaCanonPrefab;
    public int fuerzaBolas;

    //SABER SI EL JUGADOR ESTA EN EL AREA DEL CANON Y SI VA A USAR EL CANON
    bool jugadorEstaEnCanon;
    bool usandoCanon;

    //UI DEL CANON
    public GameObject spaceUI;

    //REFERENCIA DEL JUGADOR
    GameObject jugador;

    SoundManager sound;

    //VIDA CANON
    int vidaCanon = 6;

    //GENERADOR
    GeneradorMolinos generador;

    public GameObject canvas;
    public Image corazonUno, corazonDos, CorazonTres;

    MolinoGigante[] molinos;
    public GameObject muelle;

    //SALIR CANVAS
    public GameObject canvasSalir;


    int muerte = 0;

    private void Awake()
    {
        //INICIALIZAR OBJETOS REFERENTES AL CANON
        cabezaCanon = GameObject.Find("Cabeza");
        generadorBolas = GameObject.Find("GeneradorBolas");

        //DETECTAR LA CAMARA PRINCIPAL DEL JUEGO
        mainCamera = Camera.main;

        //EL JUGADOR NO ESTA EN AREA NI USANDO EL CANON
        jugadorEstaEnCanon = false;
        usandoCanon = false;

        //DESACTIVAR CAMARA CANON Y ACTIVAR LA PRINCIPAL
        mainCamera.enabled = true;
        camaraCanon.enabled = false;

        //SONIDOS
        sound = FindObjectOfType<SoundManager>();

        //GENERADOR
        generador = FindObjectOfType<GeneradorMolinos>();

        canvasSalir.SetActive(false);

        canvas.SetActive(false);
    }
    private void Start()
    {
        muelle.SetActive(false);
    }
    void Update()
    {

        if (vidaCanon <= 0 && muerte == 0)
        {
            muerte++;
            SceneManager.LoadScene("Muerte");
        }

        //CANON
        //Si el jugador esta en area, pero no usando el canon activamos la UI
        if (jugadorEstaEnCanon && !usandoCanon)
            spaceUI.SetActive(true);
        //Si el jugador no esta en area desactivamos la UI
        else
            spaceUI.SetActive(false);
        //Si estando en area y no usando el canon
        if(jugadorEstaEnCanon && !usandoCanon)
        {
            //Al pulsar el boton de interactuar, el espacio
            if(Input.GetButton("Atacar"))
            {
                //Entras en el estado de usar canon
                usandoCanon = true;
                generador.SetTempoPasa(true);
            }
        }

        //Si estas en estado de usar canon
        if(usandoCanon)
        {

            molinos = FindObjectsOfType<MolinoGigante>();

            //Activamos la camara del canon y desactivamos la camara principal
            mainCamera.enabled = false;
            camaraCanon.enabled = true;

            canvas.SetActive(true);

            //GIRAR CANON HACIA EL RATON  
            Ray mouseWordlPosition = camaraCanon.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseWordlPosition, out RaycastHit hit))
            {
                print(hit.collider.gameObject.name);
                if (hit.collider.tag == "PlanoCanon")
                    cabezaCanon.transform.LookAt(hit.point);
            }

            //GENERAR BOLA
            if (Input.GetButtonDown("Fire1"))
            {

                sound.SeleccionAudio(12, 0.5f);

                GameObject clonBolaCanon = Instantiate(bolaCanonPrefab);
                clonBolaCanon.transform.position = generadorBolas.transform.position;
                Rigidbody rBBola = clonBolaCanon.GetComponent<Rigidbody>();
                rBBola.AddForce(cabezaCanon.transform.forward * fuerzaBolas, ForceMode.Impulse);
                rBBola.AddTorque(rBBola.transform.forward * 20*Time.deltaTime);
            }

            //Si, estando en estado de uso de canon, pulsamos el boton cancel, en este caso la z, cambiamos el estado a no usando canon
            if (generador.GetEnemigos() == 30 && molinos.Length == 0)
            {
                canvasSalir.SetActive(true);
                if (Input.GetButtonDown("Cancel"))
                {
                    canvas.SetActive(false);
                    muelle.SetActive(true);
                    canvasSalir.SetActive(false);
                    usandoCanon = false;
                }
            }

        }

        // Si estamos een estado no usando canon
        else
        {
            //Volvemos a activar la camara principal y desactivamos la camara del canon
            mainCamera.enabled = true;
            camaraCanon.enabled = false;
        }


        //VIDA
        if (vidaCanon == 6)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 1;
            CorazonTres.fillAmount = 1;
        }
        if (vidaCanon == 5)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 1;
            CorazonTres.fillAmount = 0.5f;
        }
        if (vidaCanon == 4)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 1;
            CorazonTres.fillAmount = 0;
        }
        if (vidaCanon == 3)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 0.5f;
            CorazonTres.fillAmount = 0;
        }
        if (vidaCanon == 2)
        {
            corazonUno.fillAmount = 1;
            corazonDos.fillAmount = 0;
            CorazonTres.fillAmount = 0;
        }
        if (vidaCanon == 1)
        {
            corazonUno.fillAmount = 0.5f;
            corazonDos.fillAmount = 0;
            CorazonTres.fillAmount = 0;
        }
        if (vidaCanon == 0)
        {
            corazonUno.fillAmount = 0;
            corazonDos.fillAmount = 0;
            CorazonTres.fillAmount = 0;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador colisiona con el trigger del canon
        if (other.gameObject.tag == "Player")
        {
            //Activamos el bool afirmando que el jugador esta en canon
            jugadorEstaEnCanon = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Si el jugador sale del canon
        if (other.gameObject.tag == "Player")
        {
            //Desactivamos el bool que dice que el jugador esta en canon
            jugadorEstaEnCanon = false;

            jugador = other.gameObject;
        }
    }
    public bool GetUso()
    {
        return usandoCanon;
    }
    public int GetVidaCanon()
    {
        return vidaCanon;
    }
    public void SetVidaCanon(int i)
    {
        vidaCanon = i;
    }

}
