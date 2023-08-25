using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectarMonedas : MonoBehaviour
{
    DatosJugador statsPlayer;

    SoundManager sound;

    void Awake()
    {
        statsPlayer = GameObject.Find("Player").GetComponent<DatosJugador>();
        sound = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Moneda")
        {
            sound.SeleccionAudio(10, 1);
            statsPlayer.SetMonedas(statsPlayer.GetMonedas() + 1);
            Destroy(other.gameObject);
        }
    }
}
