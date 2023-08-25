using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    public void CambioDeEscena(string escena)
    {
        LevelLoader.LoadLevel(escena);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
