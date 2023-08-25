using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public Vector3 newPosition;
    float temporizador = 0.2f;
    bool activarTempo = false;

    Transform player;
    DatosJugador statsPlayer;
    NavMeshAgent navmeshPlayer;

    Animator fundidoNegro;

    private void Awake()
    {
        fundidoNegro = GameObject.Find("CanvasFundidoNegro").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activarTempo)
            temporizador -= Time.deltaTime;
        else
                temporizador = 0.2f;
        if (temporizador <= 0)
        {
            Teletransportar();
            activarTempo = false;
        }
    }

    void Teletransportar()
    {
        navmeshPlayer.enabled = false;
        player.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
        statsPlayer.SetUltimaPosicion(new Vector3(newPosition.x, newPosition.y, newPosition.z));
        statsPlayer.SaveData();
        navmeshPlayer.enabled = true;
        fundidoNegro.SetBool("Activar", false);
    }

    private void OnTriggerEnter(Collider other)
	{
        if(other.gameObject.tag == "Player")
		{
            player = other.gameObject.transform;
            navmeshPlayer = other.GetComponent<NavMeshAgent>();
            statsPlayer = other.GetComponent<DatosJugador>();

            fundidoNegro.SetBool("Activar", true);
            activarTempo = true;
        }

	}
}
