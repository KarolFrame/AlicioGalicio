using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirCofre : MonoBehaviour
{
    Animator animCofre;
    public Material matUsado;
    Renderer rendCofre;
    Light luzCofre;
    SoundManager sound;
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animCofre != null)
        {
            if(Input.GetButtonDown("Atacar"))
            {
                if(!animCofre.GetBool("seAbre"))
                    sound.SeleccionAudio(6, 1);

                animCofre.SetBool("seAbre", true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Cofre")
        {
            animCofre = other.GetComponent<Animator>();
            luzCofre = other.GetComponent<Light>();
           
        }
        if(other.gameObject.tag == "CofreFondo")
        {
            rendCofre = other.GetComponent<Renderer>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(animCofre != null)
        {
            if (animCofre.GetBool("seAbre"))
            {
                rendCofre.material = matUsado;
                if (luzCofre != null)
                    Destroy(luzCofre,0.2f);
            }
            animCofre = null;
            rendCofre = null;
        }

    }
}
