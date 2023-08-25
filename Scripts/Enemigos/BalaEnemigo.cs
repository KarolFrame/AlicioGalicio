using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    Transform tr;
    public float velocidadBalas = 4;
    DatosJugador statsPlayer;
    int danoEnemigo;

    SoundManager sound;

    float morir = 5;

    void Awake()
    {
        tr = transform;
        danoEnemigo = 1;
        statsPlayer = GameObject.Find("Player").GetComponent<DatosJugador>();

        sound = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        tr.Translate(Vector3.forward * velocidadBalas * Time.deltaTime);

        morir -= Time.deltaTime;
        if (morir <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            statsPlayer.SetVida(statsPlayer.GetVida() - danoEnemigo);
            sound.SeleccionAudio(14, 1);
            Destroy(gameObject);
        }

    }
}
