using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEnemigo : MonoBehaviour
{
    public int vida;
    private void Awake()
    {
        vida = 3;        
    }
    //GET
    public int GetVida()
    {
        return vida;
    }
    //SET
    public void SetVida(int nuevaVida)
    {
        vida = nuevaVida;
    }
}
