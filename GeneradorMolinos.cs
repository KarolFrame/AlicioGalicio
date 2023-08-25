using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMolinos : MonoBehaviour
{
    public Transform[] spawns;

    public GameObject molinoPrefab;
    int enemigos = 0;

    float tempo=2, reset=2;

    bool tempoPasa = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tempoPasa)
        {
            tempo -= Time.deltaTime;
            if (tempo <= 0)
            {
                GenerarCosa();
                tempo = reset;
            }
        }
        if (enemigos == 6)
            reset = 1;
        if (enemigos == 16)
            reset = 0.5f;
        if (enemigos == 30)
            tempoPasa = false;
    }
    void GenerarCosa()
    {
        GameObject clon = Instantiate(molinoPrefab);
        molinoPrefab.transform.position = spawns[Random.Range(0, spawns.Length)].position;
        enemigos++;
    }

    public void SetTempoPasa(bool b)
    {
        tempoPasa = b;
    }
    public int GetEnemigos()
    {
        return enemigos;
    }


}
