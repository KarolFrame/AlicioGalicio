using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoPlayer : MonoBehaviour
{
    public GameObject panelDialogos;
    public Text textoDialogo, textoNombre;
    NPCHabla npcTocas;

    string dialogoAMostrar;

    bool tocaNPC;

    SoundManager sound;

    Animator anim;

    void Awake()
    {
        panelDialogos.SetActive(false);
        tocaNPC = false;

        sound = FindObjectOfType<SoundManager>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Hablar/Secundaria") && !panelDialogos.activeSelf && tocaNPC)
        {
            GestionDialogos();
        }
        if (tocaNPC && Input.GetButtonDown("Hablar/Secundaria"))
        {
            sound.SeleccionAudio(Random.Range(7, 10), 1);
            if (anim != null)
                anim.SetBool("si", true);

        }

    }
    void GestionDialogos()
    {
        StopAllCoroutines();

            panelDialogos.SetActive(true);
            dialogoAMostrar = npcTocas.GetDialogo();
            textoNombre.text = npcTocas.GetNombre();
            npcTocas.GetUI().SetActive(false);

            StartCoroutine(MostrarDialogo());
    }

    private IEnumerator MostrarDialogo()
    {
        textoDialogo.text = string.Empty;
        foreach (char ch in dialogoAMostrar)
        {
            textoDialogo.text += ch;
            yield return new WaitForSeconds(0.025f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "NPCHabla")
        {
            tocaNPC = true;
            npcTocas = other.GetComponent<NPCHabla>();
            anim = other.GetComponent<NPCHabla>().GetAnim();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        tocaNPC = false;
        if (other.name == "NPCHabla")
        {
            panelDialogos.SetActive(false);
            npcTocas = null;
            tocaNPC = false;
        }
    }
}
