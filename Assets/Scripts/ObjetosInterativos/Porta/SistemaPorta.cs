using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPorta : MonoBehaviour
{
    [SerializeField] AudioSource audioAbrindo;
    [SerializeField] AudioSource audioFechando;
    [SerializeField] public bool estaAberta = false;
    [SerializeField] Animator anim;
    [SerializeField] public bool precisaDeChave;
    [SerializeField] public int qualChavePrecisa;
    [SerializeField] public bool estaTrancada;


    /* A CHAVE TEM QUE CHAMAR UMA VERIFICAÇÃO DA PROPRIA PORTA NA QUAL A PORTA SE ABRE CASO DEVA*/
    public void abrirPorta()
    {
        if (!estaTrancada)
        {
            estaAberta = true;
            anim.SetBool("aberta", true);
            audioAbrindo.Play();
        }
    }

    public void fecharPorta()
    {
        estaAberta = false;
        anim.SetBool("aberta", false);
        audioFechando.Play();
    }

}
