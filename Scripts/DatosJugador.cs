using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosJugador : MonoBehaviour
{
    //VARIABLES DEL JUGADOR
    int vidaJugador = 6;
    int danoEspada = 1;
    int monedas = 0;
    int bombas = 0;
    int tirachinas = 0;
    int llaves = 0;
    int pociones = 0;
    Vector3 ultimaPosicion;

    private string vidaPrefsName;
    private string danoEspadaPrefsName;
    private string monedasPrefsName;
    private string bombasPrefsName;
    private string tirachinasPrefsName;
    private string llavesPrefsName;
    private string pocionesPrefsName;
    private string posicionXPrefsName, posicionYPrefsName, posicionZPrefsName;
    private void Awake()
    {
        LoadData();
        vidaJugador = 3;
        danoEspada = 1;
        monedas = 0;
        bombas = 0;
        tirachinas = 0;
        llaves = 0;
        pociones = 0;
        ultimaPosicion = transform.position;
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt(vidaPrefsName, vidaJugador);
        PlayerPrefs.SetInt(danoEspadaPrefsName, danoEspada);
        PlayerPrefs.SetInt(monedasPrefsName, monedas);
        PlayerPrefs.SetInt(bombasPrefsName, bombas);
        PlayerPrefs.SetInt(tirachinasPrefsName, tirachinas);
        PlayerPrefs.SetInt(llavesPrefsName, llaves);
        PlayerPrefs.SetInt(pocionesPrefsName, pociones);
        //POSICION
        PlayerPrefs.SetFloat(posicionXPrefsName, ultimaPosicion.x);
        PlayerPrefs.SetFloat(posicionYPrefsName, ultimaPosicion.y);
        PlayerPrefs.SetFloat(posicionZPrefsName, ultimaPosicion.z);
    }
    public void LoadData()
    {
        vidaJugador = PlayerPrefs.GetInt(vidaPrefsName, 6);
        danoEspada = PlayerPrefs.GetInt(danoEspadaPrefsName, 1);
        monedas = PlayerPrefs.GetInt(monedasPrefsName, 0);
        bombas = PlayerPrefs.GetInt(bombasPrefsName, 0);
        tirachinas = PlayerPrefs.GetInt(tirachinasPrefsName, 0);
        llaves = PlayerPrefs.GetInt(llavesPrefsName, 0);
        pociones = PlayerPrefs.GetInt(pocionesPrefsName, 0);
        //POSICION
        ultimaPosicion.x = PlayerPrefs.GetFloat(posicionXPrefsName, transform.position.x);
        ultimaPosicion.y = PlayerPrefs.GetFloat(posicionYPrefsName, transform.position.y);
        ultimaPosicion.z = PlayerPrefs.GetFloat(posicionZPrefsName, transform.position.z);
    }

    //GET DE LAS VARIABLES
    public int GetVida()
    {
        return vidaJugador;
    }
    public int GetMonedas()
    {
        return monedas;
    }
    public int GetDanoEspada()
    {
        return danoEspada;
    }
    public int GetBombas()
    {
        return bombas;
    }
    public int GetTirachinas()
    {
        return tirachinas;
    }
    public int GetLlaves()
    {
        return llaves;
    }
    public int GetPociones()
    {
        return pociones;
    }
    public Vector3 GetUltimaPosicion()
    {
        return ultimaPosicion;
    }

    //SET DE LAS VARIABLES
    public void SetVida(int nuevaVida)
    {
        vidaJugador = nuevaVida;
    }
    public void SetMonedas(int nuevaMonedas)
    {
        monedas = nuevaMonedas;
    }
    public void SetDanoEspada(int nuevaDanoEspada)
    {
        danoEspada = nuevaDanoEspada;
    }
    public void SetBombas(int nuevaBomba)
    {
        bombas = nuevaBomba;
    }
    public void SetTirachinas(int nuevaTirachinas)
    {
        tirachinas = nuevaTirachinas;
    }
    public void SetLlaves(int nuevaLlave)
    {
        llaves = nuevaLlave;
    }
    public void SetPociones(int nuevapociones)
    {
        pociones = nuevapociones;
    }
    public void SetUltimaPosicion(Vector3 nuevaultimapos)
    {
        ultimaPosicion = nuevaultimapos;
    }
}
