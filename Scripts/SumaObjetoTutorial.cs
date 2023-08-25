using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumaObjetoTutorial : MonoBehaviour
{
    Tutorial tutorial;
    private void Awake()
    {
        tutorial = FindObjectOfType<Tutorial>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            tutorial.SumarObjetoRecogido();
        }
            
    }
}
