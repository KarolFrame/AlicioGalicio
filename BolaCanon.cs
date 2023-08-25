using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCanon : MonoBehaviour
{
    float morir=8;
    SoundManager sound;
    private void Awake()
    {
        sound = FindObjectOfType<SoundManager>();
    }
    void Update()
    {
        morir -= Time.deltaTime;
        if (morir <= 0)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Molino")
        {
            Animator animMolino = collision.gameObject.GetComponentInChildren<Animator>();
            if(animMolino != null)
            {
                sound.SeleccionAudio(13, 1);
                animMolino.SetBool("muere", true);
                Destroy(collision.gameObject, 0.5f);
            }
        }
    }
}
