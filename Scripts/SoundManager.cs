using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioClip[] audios;
    [SerializeField] AudioClip[] musicas;
    public AudioSource controlAudio;
    public AudioSource musicaFondo;



    private void Awake()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }
        else
            LoadVolume();

        SeleccionMusica(1, 0.8f);
    }

    public void SeleccionAudio(int i, float volume)
    {
        controlAudio.PlayOneShot(audios[i], volume);
    }
    public void SeleccionMusica(int i, float volume)
    {
        volume = 0.8f;
        musicaFondo.clip = musicas[i];
        musicaFondo.volume = volume;
        musicaFondo.Play();
    }
    public void PulsarBoton()
    {
        SeleccionAudio(3, 1);
    }
    public void CambiarVolumen()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }
    private void LoadVolume()
    {
        if(volumeSlider != null)
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    public void ComprasAudio()
    {
        SeleccionAudio(11, 1);
    }
}
