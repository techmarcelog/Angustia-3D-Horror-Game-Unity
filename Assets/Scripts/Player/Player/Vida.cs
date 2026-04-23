using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    [SerializeField] int limiteVida = 5;
    int quantidadeVida;

    private void Awake()
    {
        quantidadeVida = limiteVida;
    }

    public int Get_Vida()
    {
        return quantidadeVida;
    }

    public void AdicionarVida(int qtdGanhoVida)
    {
        if (quantidadeVida + qtdGanhoVida > limiteVida)
        {
            quantidadeVida = limiteVida;
            return;
        }

        quantidadeVida += qtdGanhoVida;
    }
     
    public void RemoverVida(int qtdPerdaVida)
    {
        if (quantidadeVida - qtdPerdaVida < 1) 
        {
            //Morrer();
            return;
        }

        quantidadeVida -= qtdPerdaVida;
    }

    //private void Morrer()
    //{
    //    Destroy(this.gameObject/*.GetComponent<Movimentacao>()*/);
    //}

    //void seMatar() //MÉTODO DE TESTE
    //{
    //    Morrer();

    //}

}


