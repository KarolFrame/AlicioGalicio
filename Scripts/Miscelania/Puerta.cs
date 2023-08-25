using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    //COMPONENTES
    Animator anim;
    SoundManager sound;
    private void Awake()
    {
        //INICIALIZAR
        anim = GetComponent<Animator>();
        sound = FindObjectOfType<SoundManager>();
    }

    //SET bool DE ANIMATOR
    public void SetSeAbre(bool seAbre)
    {
        anim.SetBool("SeAbre", seAbre);

        sound.SeleccionAudio(5,0.5f);
    }
}
