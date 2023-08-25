using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Compi : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    NPCMision npc;
    public Animator anim;
    Transform tr;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        npc = GetComponent<NPCMision>();
        target = null;
        npc.enabled = false;
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
            if(Vector3.Distance(tr.position, target.position)<= agent.stoppingDistance)
                anim.SetBool("mov", false);
            else
                anim.SetBool("mov", true);
        }
        npc.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            target = other.GetComponent<Transform>();
        }
    }
}
