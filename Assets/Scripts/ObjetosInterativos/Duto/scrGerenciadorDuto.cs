using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrGerenciadorDuto : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Movimentacao>().podeTeclar_Agachar = false;
            other.gameObject.GetComponent<Movimentacao>().DefinirNovoEstado(Movimentacao.estadoPlayer.agachando);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Movimentacao>().podeTeclar_Agachar = true;
        }
    }
}
