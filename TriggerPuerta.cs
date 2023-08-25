using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPuerta : MonoBehaviour
{
    public Puerta puerta;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            puerta.SetSeAbre(true);
        }
    }
}
