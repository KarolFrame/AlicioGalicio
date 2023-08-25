using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coger : MonoBehaviour
{
    //Punto en el que quieres que este el objeto que coges
    public GameObject manoPoint;
    //El objeto que el jugador coge
    GameObject objetoQueCoges;

    bool objetoEnArea;
    bool tienesObjeto;

    Animator animPlayer;

    SoundManager sound;

    private void Awake()
    {
        //No asignamos nada al objeto que coges
        objetoQueCoges = null;

        objetoEnArea = false;
        tienesObjeto = false;

        animPlayer = GameObject.Find("Alicio").GetComponent<Animator>();

        sound = FindObjectOfType<SoundManager>();

    }

    void Update()
    {

        if(objetoEnArea && objetoQueCoges != null)
        {

            if(Input.GetButtonDown("Coger"))
            {
                if(tienesObjeto) //SOLTAR
                {
                    //Animacion de soltar
                    animPlayer.SetBool("Coge", false);
                    //El objeto adquiere gravedad
                    objetoQueCoges.GetComponent<Rigidbody>().useGravity = true;
                    //El objeto ya no es kinematico
                    objetoQueCoges.GetComponent<Rigidbody>().isKinematic = false;
                    //El objeto ya no es hijo del jugador
                    objetoQueCoges.gameObject.transform.SetParent(null);
                    //La variable objeto que coges se vacia
                    objetoQueCoges = null;
                    //Ya no teiens objeto en la mano
                    tienesObjeto = false;
                }
                else //COGER
                {
                    //Animacion de coger
                    animPlayer.SetBool("Coge", true);
                    //El objeto deja de hacer caso a la gravedad
                    objetoQueCoges.GetComponent<Rigidbody>().useGravity = false;
                    //El objeto es kinematico
                    objetoQueCoges.GetComponent<Rigidbody>().isKinematic = true;
                    //El objeto se teletransponta al punto que establecimos
                    objetoQueCoges.transform.position = manoPoint.transform.position;
                    //El objeto se transforma en hijo del jugador
                    objetoQueCoges.gameObject.transform.SetParent(manoPoint.gameObject.transform);
                    //La variable objeto que coges se llena con el objeto con el que colisionaste
                    objetoQueCoges = objetoQueCoges.gameObject;
                    //Tienes un objeto en la mano
                    tienesObjeto = true;
                    //Suena coger
                    sound.SeleccionAudio(16, 1);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        //Si entra en el trigger un objeto con el tag Objeto
        if(other.gameObject.CompareTag("Objeto"))
        {
            //Si pulsas el boton de Interactuat y no tienes la variable objeto que coges asignada
            if (Input.GetButton("Coger") && objetoQueCoges == null)
            {
                //El objeto deja de hacer caso a la gravedad
                other.GetComponent<Rigidbody>().useGravity = false;
                //El objeto es kinematico
                other.GetComponent<Rigidbody>().isKinematic = true;
                //El objeto se teletransponta al punto que establecimos
                other.transform.position = manoPoint.transform.position;
                //El objeto se transforma en hijo del jugador
                other.gameObject.transform.SetParent(manoPoint.gameObject.transform);
                //La variable objeto que coges se llena con el objeto con el que colisionaste
                objetoQueCoges = other.gameObject;
                //Tienes un objeto en la mano
            }
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        objetoEnArea = true;
        if (other.gameObject.CompareTag("Objeto") && objetoQueCoges == null)
            objetoQueCoges = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == objetoQueCoges)
        {
            objetoQueCoges = null;
        }
    }

}
