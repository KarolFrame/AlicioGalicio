using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class ControlLookAtNPC : MonoBehaviour
{
    LookAtConstraint lookAt;
    Player jugador;
    Transform tr;
    void Awake()
    {
        lookAt = GetComponent<LookAtConstraint>();
        tr = transform;
        jugador = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(tr.position, jugador.transform.position)<=4)
        {
            lookAt.enabled = true;
        }
        else
            lookAt.enabled = false;
    }
}
