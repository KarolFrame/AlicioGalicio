using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorCanvas : MonoBehaviour
{
    Canvas[] canvas;
    void Start()
    {
        canvas = FindObjectsOfType<Canvas>();
        for (int i = 0; i < canvas.Length; i++)
        {
            if (canvas[i].gameObject.name != "CanvasCarga")
            {
                canvas[i].enabled = false;
            }
        }
    }
}
