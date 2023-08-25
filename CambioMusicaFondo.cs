using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMusicaFondo : MonoBehaviour
{
    public int i;
    public float volumen;
    
    SoundManager sound;
    private void Awake()
    {
        sound = FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            sound.SeleccionMusica(i,volumen);
        }
    }
}
