using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomba : MonoBehaviour
{
    public float radio = 5, fuerzaExplosion = 5;
    public float temporizador;

    SoundManager sound;

    void Awake()
    {
        temporizador = 5;
        sound = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        temporizador -= Time.deltaTime;
        if(temporizador <=0)
        {
            Explota();
            sound.SeleccionAudio(2,0.5f);
            Destroy(gameObject,0.05f);
        }
    }
    void Explota()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);

        foreach(Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if(rigg !=null && rigg.gameObject.tag !="Player" && rigg.gameObject.name != "NPCHabla"  && rigg.gameObject.name != "NPCMision" )
            {
                if (rigg.isKinematic && rigg.gameObject.tag == "Grieta")
                    rigg.isKinematic = false;
                NavMeshObstacle obstacleNav = rigg.gameObject.GetComponent<NavMeshObstacle>();
                if (obstacleNav != null)
                    obstacleNav.enabled = false;
                DestruirPorExplosion cosa = rigg.gameObject.GetComponent<DestruirPorExplosion>();
                if (cosa != null)
                    cosa.Destruir();
                rigg.AddExplosionForce(fuerzaExplosion, transform.position, radio);
                DatosEnemigo enemigo = rigg.gameObject.GetComponent<DatosEnemigo>();
                if (enemigo != null)
                    enemigo.SetVida(0);
            }

        }
    }
}
