using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarPlayer : MonoBehaviour
{
    public GameObject prefabPLayer;
    GameController[] gC;
    Canvas[] canvas;
    void Awake()
    {
        gC = FindObjectsOfType<GameController>();
        if(gC.Length > 1)
        {
            for (int i = 0; i < gC.Length; i++)
            {
                if (i > 0)
                    Destroy(gC[i].gameObject);
            }
        }
        canvas = FindObjectsOfType<Canvas>();
        for (int i = 0; i < canvas.Length; i++)
        {
            canvas[i].enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
