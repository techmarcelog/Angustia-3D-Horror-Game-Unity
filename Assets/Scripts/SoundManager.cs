using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider sliderVolume;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volumeAtual"))
        {
            PlayerPrefs.SetFloat("volumeAtual", 1);
            Carregar();
        }
        else
        {
            Carregar();
        }
    }

    // Update is called once per frame
    public void MudarVolume()
    {
        AudioListener.volume = sliderVolume.value;
        Salvar();
    }

    private void Carregar()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("volumeAtual");
    }
    private void Salvar()
    {
        PlayerPrefs.SetFloat("volumeAtual", sliderVolume.value);
    }
}
