using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeMonedas : MonoBehaviour
{
    public GameObject monedaPrefab;
    Transform tr;
    int numeroMonedas = 0;
    float gradosCirculo = 360;
    float arco = 0;

    //UI LIGADA
    public GameObject uI;

    void Awake()
    {
        tr = transform;
        if(uI != null)
        uI.SetActive(false);
    }

    public void GenerarMoneda()
    {
        numeroMonedas = Random.Range(5,15);

        arco = (float)gradosCirculo / numeroMonedas;

        GameObject prefab;

        for (int i = 0; i < numeroMonedas; i++)
        {
            prefab = Instantiate(monedaPrefab, tr.position, Quaternion.identity);
            prefab.transform.Rotate(Vector3.up, i * arco);
        }
        /*
        Rigidbody rBMoneda = monedaPrefab.GetComponent<Rigidbody>();
        rBMoneda.isKinematic = false;
        rBMoneda.AddForce(tr.forward * fuerzaMonedas, ForceMode.Impulse);*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && uI != null)
            uI.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && uI != null)
            uI.SetActive(false);
    }
}



