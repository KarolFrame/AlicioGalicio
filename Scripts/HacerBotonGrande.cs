using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HacerBotonGrande : MonoBehaviour
{
    RectTransform tr;
    SoundManager soundManager;

    private void Awake()
    {
        tr = GetComponent<RectTransform>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    
    public void HacerseGrande()
    {
        tr.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        soundManager.SeleccionAudio(22, 0.5f);
    }
    public void HacerseNormal()
    {
        tr.localScale = new Vector3(1, 1, 1);
    }
}
