using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrObjInstanceManager : MonoBehaviour
{
    [SerializeField] scrCheckpointManager scriptCheckpointManager;
    [SerializeField] string nomeLayerItens;

    [Header("Itens de cena")]
    [SerializeField] List<GameObject> itensNaCena;
    [SerializeField] List<bool> itensNaCenaExistentes;

    /*
    [Header("Itens realocados")]
    [SerializeField] List<GameObject> itensRealocados;
    [SerializeField] List<bool> itensRealocadosExistentes;
    */

    private void Awake()
    {
        foreach (GameObject objetoNoCenario in FindObjectsOfType(typeof(GameObject)))
        {
            if (objetoNoCenario.layer == LayerMask.NameToLayer(nomeLayerItens) && objetoNoCenario.CompareTag("Item"))
            {
                itensNaCena.Add(objetoNoCenario);
                itensNaCenaExistentes.Add(objetoNoCenario.activeInHierarchy);
            }
        }
    }

    private void Update()
    {
        verificarExistencia_Itens();
    }

    private void verificarExistencia_Itens()
    {
        for (int i = 0; i < itensNaCena.Count; i++)
        {
            if (itensNaCena[i] == null || !itensNaCena[i].activeInHierarchy)
            {                
                itensNaCenaExistentes[i] = false;
            }
            else
            {
                itensNaCenaExistentes[i] = true;
            }
        }
    }

    public void AtualizarValores()
    {
        itensNaCena.Clear();
        itensNaCenaExistentes.Clear();

        foreach (GameObject objetoNoCenario in FindObjectsOfType(typeof(GameObject)))
        {
            if (objetoNoCenario.layer == LayerMask.NameToLayer(nomeLayerItens))
            {
                itensNaCena.Add(objetoNoCenario);
                itensNaCenaExistentes.Add(objetoNoCenario.activeInHierarchy);
            }
        }
    }

    public void DesativarItensJaInexistentes(List<bool> itensExistentes)
    {
        for (int i = 0; i < itensNaCena.Count; i++)
        {
            if (!itensExistentes[i])
            itensNaCena[i].SetActive(false);            
        }
    }

    public List<bool> getItensNaCenaExistentes()
    {
        return itensNaCenaExistentes;
    }



    /*
     tem que ter um bool para contar os objetos que existem ou n no mundo a partir de um array ou sla de objetos que foram 
    contados no começo do jogo
     
    ;;; ====== ABAIXO TÁ UM SCRIPT ANTIGO ONDE DÁ PRA PEGAR ALGUMA COISA ÚTIL DELE PRA FAZER ALGUMA OUTRA PARTE DO CÓDIGO;;;;;

    [SerializeField] Vector3 posicaoCulling; // "Limbo"/"culling" = local onde serão escondidas as novas instâncias dos objetos

    [SerializeField] LayerMask camadaObjetosCenario;
    [SerializeField] string nomeLayerObjetos;

    [SerializeField] List<GameObject> itensDoCenario_Referencia;
    [SerializeField] List<bool> itensDoCenario_Existem;

    [SerializeField] List<GameObject> objetosRealocados_Referencia;
    [SerializeField] List<GameObject> objetosRealocados_Clone;

    [SerializeField] List<Vector3> posicaoObjetosRealocados;

    private void Start()
    {
        Debug.Log("Called"); 
        posicaoCulling = new Vector3(17, 10, -14);
    }



    private void Update()
    {
        for (int i = 0; i < itensDoCenario_Referencia.Count; i++)
        {
            if (itensDoCenario_Referencia[i] == null)
            {
                // Debug.Log("Um item guardado foi removido!");
            }

        }


    }

    public List<bool> contarObjsDoCenarioExistentes()
    {
        for (int i = 0; i < itensDoCenario_Referencia.Count; i++)
        {
            if (itensDoCenario_Referencia[i] == null)
            {
                itensDoCenario_Existem[i] = false;
                Debug.Log("O índice " + i.ToString() + " não existe");
            }
        }
        
        return itensDoCenario_Existem;
    }

    private List<GameObject> contarObjsDoCenario()
    {
        foreach (GameObject objeto in FindObjectsOfType(typeof(GameObject)))
        {
            if (objeto.layer == LayerMask.NameToLayer(nomeLayerObjetos))
            {
                itensDoCenario_Referencia.Add(objeto);
                itensDoCenario_Existem.Add(true);

                //  LEIA!!!!!!       posicaoObjetosRealocados.Add(new Vector3(objeto.transform.position.x, objeto.transform.position.y, objeto.transform.position.z));

                //cloneObjeto.SetActive(false);

            }
        }
    }

    public void OcultarItensPegos()
    {
        List<GameObject> objsDoCenarioAtual = contarObjsDoCenario();
        for(int i = 0; i < objsDoCenarioAtual.Length; i++)
        {
            if (!itensDoCenario_Existem[i])
            {
                objsDoCenarioAtual[i].SetActive(false);
            }
        }
    }

    /*
    private void DefinirObjetosCenario()
    {
        foreach (GameObject objeto in FindObjectsOfType(typeof(GameObject)))
        {
            if (objeto.layer == LayerMask.NameToLayer(nomeLayer))
            {
                itensDoCenario_Referencia.Add(objeto);
                itensDoCenario_Existem.Add(true);

                //  LEIA!!!!!!       posicaoObjetosRealocados.Add(new Vector3(objeto.transform.position.x, objeto.transform.position.y, objeto.transform.position.z));

                //cloneObjeto.SetActive(false);

            }
            else
            {
                Debug.Log("Não adicionou. De " + FindObjectsOfType(typeof(GameObject)).Length.ToString() + " \n por estar em" + LayerMask.LayerToName(objeto.layer));
            }
        }
    }

    private void apagarItensJaPegos()
    {
        for (int i = 0; i < itensDoCenario_Existem.Count; i++)
        {
            if (itensDoCenario_Existem[i] == false)
            {
                itensDoCenario_Referencia[i].SetActive(false);
                Debug.Log("Item " + itensDoCenario_Referencia[i].name + " foi deletado.");
            }
            else
            {
                Debug.Log("o item " + itensDoCenario_Referencia[i].name + "existe.");
            }
        }
    }

    private void recolocarItensRealocados()
    {
        for (int i = 0; i < objetosRealocados_Clone.Count; i++)
        {
            if (objetosRealocados_Referencia[i] != null)
            {
                Instantiate(objetosRealocados_Clone[i], posicaoObjetosRealocados[i], Quaternion.identity);
            }
        }
    }

    public void verificarExistencia_ItensDoCenario()
    {
        for (int i = 0; i < itensDoCenario_Existem.Count; i++)
        {
            if (itensDoCenario_Referencia[i] == null)
            {
                itensDoCenario_Existem[i] = false;
                Debug.Log("O índice " + i.ToString() + " não existe");
            }
        }

    }

    */
}
