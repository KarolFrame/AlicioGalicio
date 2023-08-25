using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManagerTienda : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void ChiquetaHabla()
    {
        anim.SetTrigger("Habla");
    }
    public void ChiquetaLeCompran()
    {
        anim.SetTrigger("Comprar");

    }
}
