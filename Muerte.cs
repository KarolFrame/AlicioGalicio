using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Muerte : MonoBehaviour
{
    DatosJugador statsPlayer;
    int muerte = 0;

    private void Awake()
    {
        statsPlayer = FindObjectOfType<DatosJugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (statsPlayer.GetVida() <= 0 && muerte ==0)
        {
            muerte++;
            SceneManager.LoadScene("Muerte");
        }
    }
    public void SetearMuerte()
    {
        muerte = 0;
    }
}
