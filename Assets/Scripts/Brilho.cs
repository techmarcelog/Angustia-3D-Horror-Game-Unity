using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brilho : MonoBehaviour
{
    public Slider sliderBrilho;
    public PostProcessProfile brilho;
    public PostProcessLayer camada;
    AutoExposure exposicao;

    void Start()
    {
        brilho.TryGetSettings(out exposicao);
        AjustarBrilho(sliderBrilho.value);
    }

    public void AjustarBrilho(float valor)
    {
        if(valor != 0)
        {
            exposicao.keyValue.value = valor;
        }
        else
        {
            exposicao.keyValue.value = .05f;
        }
    }
}
