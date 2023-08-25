using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuaraController : MonoBehaviour
{
    float tempo = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo -= Time.deltaTime;
        if(tempo<=0)
        {
            LevelLoader.LoadLevel("Menu");
        }
    }
}
