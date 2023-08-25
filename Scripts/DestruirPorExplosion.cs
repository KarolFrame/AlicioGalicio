using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorExplosion : MonoBehaviour
{
    Animator anim;
    float temporizador;
    bool activarTempo;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        activarTempo = false;
        temporizador = 1f;
    }

    void Update()
    {
        if(activarTempo)
        {
            temporizador -= Time.deltaTime;
        }
        if(temporizador<=0)
        {
            anim.SetBool("ActivarParpadeo", true);
            anim.speed += 2*Time.deltaTime;
        }
    }
    public void Destruir()
    {
        activarTempo = true;
        
        Destroy(gameObject, 3);
    }
}
