using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteController : MonoBehaviour
{
    float tempo = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if(tempo <= 0)
        {
            LevelLoader.LoadLevel("Menu");
        }
    }
}
