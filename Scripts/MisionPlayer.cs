using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionPlayer : MonoBehaviour
{
    public GameObject panelMison;

    public Text textoMision, textoNombre;
    public Button btnSI;
    public Button btnNO;

    string dialogoAMostrar;

    NPCMision npcTocas;

    bool tocaNPC;

    SoundManager sound;

    void Awake()
    {
        panelMison.SetActive(false);
        tocaNPC = false;
        sound = FindObjectOfType<SoundManager>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Hablar/Secundaria") && !panelMison.activeSelf&&tocaNPC)
        {
            GestionDialogos();

        }
        if(tocaNPC && Input.GetButtonDown("Hablar/Secundaria"))
        {
            sound.SeleccionAudio(Random.Range(7, 10), 1);
        }


    }
    void GestionDialogos()
    {
        StopAllCoroutines();

            panelMison.SetActive(true);
            dialogoAMostrar = npcTocas.GetDialogo();
            npcTocas.GetUI().SetActive(false);
            textoNombre.text = npcTocas.GetNombre();

            btnNO.enabled = true;
            btnSI.enabled = true;

            StartCoroutine(MostrarDialogo());

    }

    private IEnumerator MostrarDialogo()
    {
        textoMision.text = string.Empty;
        foreach(char ch in dialogoAMostrar)
        {
            textoMision.text += ch;
            yield return new WaitForSeconds(0.025f);
        }
    }

    public void BtnSI()
    {
        if(npcTocas)
        {
            npcTocas.BtnSI();
            GestionDialogos();

            btnNO.enabled = false;
            btnSI.enabled = false;
        }
    }
    public void BtnNO()
    {
        if (npcTocas)
        {
            npcTocas.BtnNO();
            GestionDialogos();

            btnNO.enabled = false;
            btnSI.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "NPCMision")
        {
            tocaNPC = true;
            npcTocas = other.GetComponent<NPCMision>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tocaNPC = false;
        if (other.name == "NPCMision")
        {
            panelMison.SetActive(false);
            npcTocas = null;
            tocaNPC = false;
        }
    }
}
