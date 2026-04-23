using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanidade : MonoBehaviour
{
    [SerializeField] int limiteSanidade = 100;
    [SerializeField] public int quantidadeSanidade;

    [SerializeField] public CanvasGroup painelSanidade;
    [SerializeField] AudioSource audioSanidade1;
    [SerializeField] AudioSource audioSanidade2;
    [SerializeField] AudioSource audioSanidade3;
    [SerializeField] AudioSource audioSanidade4;
    private void Awake() 
    {
       quantidadeSanidade = limiteSanidade;
    }

    private void Start()
    {
        painelSanidade.alpha = 0.0f;
        InvokeRepeating("DescrescerSanidade", 0f, 2f);
    }

    private void Update()
    {
        if (painelSanidade.alpha > 0.7f)
        {
            painelSanidade.alpha = 0.7f;
        }
        if (quantidadeSanidade <= 75.0f && quantidadeSanidade >= 65.0f)
        {
            painelSanidade.alpha = 0.2f;
            audioSanidade1.enabled = true;
        }
        else if (quantidadeSanidade <= 50.0f && quantidadeSanidade >= 40.0f)
        {
            painelSanidade.alpha = 0.4f;
            audioSanidade2.enabled = true;
        }
         else if (quantidadeSanidade <= 25.0f && quantidadeSanidade >= 15.0f)
        {
            painelSanidade.alpha = 0.8f;
            audioSanidade3.enabled = true;
        }
         else if (quantidadeSanidade == 1.0f)
        {
            painelSanidade.alpha = 1f;
            audioSanidade4.enabled = true;
        }
        else
        {
            audioSanidade1.enabled = false;
            audioSanidade2.enabled = false;
            audioSanidade3.enabled = false;
            audioSanidade4.enabled = false;
        }

    }

    public int Get_Sanidade()
    {
        return quantidadeSanidade;
    }

    public void AdicionarSanidade(int qtdGanhoSanidade)
    {
        if (quantidadeSanidade + qtdGanhoSanidade > limiteSanidade)
        {
            quantidadeSanidade = limiteSanidade;
            return;
        }
        painelSanidade.alpha = quantidadeSanidade / 100;
        quantidadeSanidade +=  qtdGanhoSanidade;
    }

    public void RemoverSanidade(int qtdPerdaSanidade)
    {
        if (quantidadeSanidade - qtdPerdaSanidade < 1)
        {
            Enlouquecer();
            return;
        }

        quantidadeSanidade -= qtdPerdaSanidade;        
    }

    private void Enlouquecer()
    {
        //Debug.Log("Player ficou biruta HAHAHAHAHAHAH >:D");
        Debug.Log("Sanidade foi zerada. Jogador perderá vida");
        this.gameObject.GetComponent<PlayerController>().Morreu();
    }

    private void DescrescerSanidade()
    {
        RemoverSanidade(1);
        painelSanidade.alpha = painelSanidade.alpha + 0.01f;
    }
}
