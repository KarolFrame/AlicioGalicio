using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuaraTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            LevelLoader.LoadLevel("Continuara");
        }
    }
}
