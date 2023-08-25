using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoDistancia : MonoBehaviour
{
    DatosJugador player;

    int danoEnemigo;
    int cadacuantopega;
    float cooldown;

    public BalaEnemigo prefabBala;
    public Transform spawnBalas;
    Animator animEnemigo;

    Transform tr;

    bool dispara = false;

    SoundManager sound;
    void Awake()
    {
        tr = transform;
        animEnemigo = GetComponentInChildren<Animator>();

        danoEnemigo = 1;
        cadacuantopega = 1;

        player = FindObjectOfType<DatosJugador>();

        sound = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (dispara)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                animEnemigo.SetTrigger("Ataca");
                Instantiate(prefabBala, spawnBalas.transform.position, spawnBalas.transform.rotation);
                sound.SeleccionAudio(20, 1);
                cooldown = cadacuantopega;
            }
        }
        if (Vector3.Distance(tr.position, player.transform.position) >= 6)
        {
            dispara = false;
        }
        else
            dispara = true;
    }
}
