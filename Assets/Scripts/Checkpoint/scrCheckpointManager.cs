using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class scrCheckpointManager : MonoBehaviour
{

    /*
     Fazer dois objetos com os itens de referência
    1º tendo referência dos objetos da cena e o 2º com uma cópia deles para ser pega quando o jogo recomeçar
    e então quando o jogo reiniciar ele vai saber quais são os objetos que devem ser instanciados ou não

    para os objetos colocados no mundo dnv eles serão colocados em outro array para itens realocados e uma cópia desse array então faz a mesma coisa
    com os objetos da cena que eu mencionei antes
     
     */



    [Header("General")]
    static GameObject instancia;

    [SerializeField] Vector3 posicaoAtual;

    Inventario inventarioAtual;

    scrObjInstanceManager scriptObjectInstanceManager;
    [SerializeField] List<bool> valoresAnteriores_ItensNaCenaExistentes;

    private void Start()
    {
        if (instancia == null)
        {
            instancia = this.gameObject;
            DontDestroyOnLoad(gameObject);

            posicaoAtual = Vector3.zero;
            scriptObjectInstanceManager = GetComponent<scrObjInstanceManager>();
        }
        else
        {
            Destroy(this.gameObject);
            return;

        }
    }

    public void SetCheckpoint(Vector3 novaPosicao)
    {
        if (novaPosicao != posicaoAtual)
        {
            atribuirValorAtual_ValoresItensNaCenaExistentes();
        }
        posicaoAtual = novaPosicao;
    }

    public Vector3 GetCheckpoint()
    {
        return posicaoAtual;
    }
    
    public bool checkpointJaFoiUsado()
    {
        if (posicaoAtual != Vector3.zero) return true;
        else return false;
    }

    public void atribuirValorInicial_ValoresItensNaCenaExistentes()
    {
        for (int i = 0; i < scriptObjectInstanceManager.getItensNaCenaExistentes().Count; i++)
        {
            valoresAnteriores_ItensNaCenaExistentes.Add(scriptObjectInstanceManager.getItensNaCenaExistentes()[i]);
        }
    }

    public void atribuirValorAtual_ValoresItensNaCenaExistentes()
    {
        for (int i = 0; i < scriptObjectInstanceManager.getItensNaCenaExistentes().Count; i++)
        {
            valoresAnteriores_ItensNaCenaExistentes[i] = scriptObjectInstanceManager.getItensNaCenaExistentes()[i];
        }
    }

    public void desativarItensDoCenarioJaPegos()
    {
        scriptObjectInstanceManager.AtualizarValores();
        scriptObjectInstanceManager.DesativarItensJaInexistentes(valoresAnteriores_ItensNaCenaExistentes);
    }

    private void recarregarCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /*                                              DESCOMENTE ISSO!!!!
    private void adicionarItensRealocados()
    {
        posicaoObjetosRealocados.Add(new Vector3(objeto.transform.position.x, objeto.transform.position.y, objeto.transform.position.z));
    }
    */



}


