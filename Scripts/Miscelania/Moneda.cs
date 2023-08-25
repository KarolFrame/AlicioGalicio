using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    Rigidbody rb;

    bool subida = true;
    bool apertura = false;
    float temporizador = 0f;
    Collider colliderMoneda;

    float velocidad = 6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        colliderMoneda = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(subida)
        {
            if(temporizador>= 0.3f)
            {
                subida = false;
                apertura = true;
                temporizador = 0;
                rb.isKinematic = false;
            }
            this.transform.Translate(Vector3.up*velocidad*Time.deltaTime);
            temporizador += Time.deltaTime;
            rb.isKinematic = false;
            colliderMoneda.enabled = false;
        }
        if(apertura)
        {
            if(temporizador>=0.40)
            {
                rb.useGravity = true;
                rb.isKinematic = false;
                apertura = false;
                temporizador = 0;
                colliderMoneda.enabled = true;
            }
            rb.isKinematic = false;
            this.transform.Translate(Vector3.forward * (velocidad - 2) * Time.deltaTime);
            temporizador += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Suelo")
        {
            rb.isKinematic = true;

        }
    }
}
