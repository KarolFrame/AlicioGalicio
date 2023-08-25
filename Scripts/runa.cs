using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runa : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            anim.SetBool("jugadorEntra", true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            anim.SetBool("jugadorEntra", false);
    }
}
