using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MolinoGigante : MonoBehaviour
{
    canon canon;

    NavMeshAgent agent;
    Transform tr;

    public AspaAtaque aspa;

    private void Awake()
    {
        canon = FindObjectOfType<canon>();
        agent = GetComponent<NavMeshAgent>();
        tr = transform;

        agent.destination = canon.transform.position;
    }

    void Update()
    {

        if(Vector3.Distance(tr.position, canon.transform.position)<=20.5f)
        {
            aspa.SetAtaca(true);
        }

    }
}
