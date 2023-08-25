using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerGrandeObjetos : MonoBehaviour
{
    public void HacerGrande(Transform objeto)
    {
        objeto.localScale = new Vector3(objeto.localScale.x+100, objeto.localScale.y + 100, objeto.localScale.z + 100);
    }
    public void HacerNormal(Transform objeto)
    {
        objeto.localScale = new Vector3(objeto.localScale.x - 100, objeto.localScale.y - 100, objeto.localScale.z - 100);
    }

}
