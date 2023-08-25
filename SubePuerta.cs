using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubePuerta : MonoBehaviour
{
    public Animator puertaAnima;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            puertaAnima.SetBool("Sube", true);
        }
    }
}
