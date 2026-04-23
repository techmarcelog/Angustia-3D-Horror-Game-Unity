using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistGaveta : MonoBehaviour
{
    [SerializeField] public AudioSource audioGavetaAbrindo;
    [SerializeField] public AudioSource audioGavetaFechando;
    [SerializeField] Animator anim;
    [SerializeField] public bool estaAberta;

    public void abrirGaveta()
    {
        estaAberta = true;
        anim.SetBool("aberta", true);
        audioGavetaAbrindo.Play();

    }

    public void fecharGaveta()
    {
        estaAberta = false;
        anim.SetBool("aberta", false);
        audioGavetaFechando.Play();
    }
}
