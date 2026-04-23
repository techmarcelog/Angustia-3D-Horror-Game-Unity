using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;
using UnityEngine.UI;
using TMPro;

public class InventarioV2 : MonoBehaviour
{
    public int qtdSeringas;
    public int qtdRemedios;
    public int qtdBaterias;
    DetecInteracao scrDetecInteracao;
    [SerializeField] ScrItemPilha scrPilha;
    [SerializeField] scrItem_Remedio scrRemedio;
    [SerializeField] scrItem_Seringa scrSeringa;
    [SerializeField] public scrItemLanterna scrLanterna;
    [SerializeField] scrItemPeDeCabra scrPeDeCabra;
    [SerializeField] AudioSource AudioItemPego;

    public GameObject UltimoItemTotemPego;
    public GameObject UltimaChavePega;

    [SerializeField] GameObject gameObjectItemPego;

    [SerializeField] TMP_Text txtQtdPilha;
    [SerializeField] TMP_Text txtQtdRemedio;
    [SerializeField] TMP_Text txtQtdSeringa;
    [SerializeField] GameObject tutorialQuarto;
    bool metodoChamado = false;

    public bool inventarioEstaAberto;
    
    public Item[] inventario = new Item[2];
    public int indiceAtualInventario = 0;
    int quantidadeItensInventario = 0;

    gameController gc;
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
        inventarioEstaAberto = false;
        scrDetecInteracao = this.gameObject.GetComponentInChildren<DetecInteracao>();
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventarioEstaAberto = !inventarioEstaAberto;
            if (!inventarioEstaAberto) indiceAtualInventario = 0;
        }

        if (!inventarioEstaAberto)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) indiceAtualInventario++;
            if (Input.GetKeyDown(KeyCode.DownArrow)) indiceAtualInventario--;

            if (indiceAtualInventario < 0 || indiceAtualInventario > inventario.Length - 1) indiceAtualInventario = 0;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) indiceAtualInventario++;
            if (Input.GetKeyDown(KeyCode.DownArrow)) indiceAtualInventario--;

            if (indiceAtualInventario > inventario.Length- 1) indiceAtualInventario = 0;
            if (indiceAtualInventario < 0) indiceAtualInventario = inventario.Length - 1;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                inventario[indiceAtualInventario].Usar();
                inventario[indiceAtualInventario] = null;
                reorganizarItens();
            }
           
        }
        if (scrDetecInteracao.deteccaoEhUmItem())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PegarItemDetectado();
            }
        }
        #region Usar Itens       

        if (Input.GetKeyDown(KeyCode.Alpha1) && qtdBaterias > 0)
        {
            scrPilha.Usar();
            qtdBaterias--;
            AtualizarValoresItens();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && qtdSeringas > 0)
        {
            scrSeringa.Usar();
            qtdSeringas--;
            AtualizarValoresItens();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && qtdRemedios > 0)
        {
            scrRemedio.Usar();
            qtdRemedios--;
            AtualizarValoresItens();
        }
        

        if (UltimoItemTotemPego != null && Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Pegou item no totem");
            UltimoItemTotemPego.GetComponent<Item>().Usar();
            UltimoItemTotemPego = null;
        }
        #endregion
    }

    private void AtualizarValoresItens()
    {
        txtQtdPilha.text = qtdBaterias.ToString();
        txtQtdSeringa.text = qtdSeringas.ToString();
        txtQtdRemedio.text = qtdRemedios.ToString();

    }

    private void PegarItemDetectado()
    {
        gameObjectItemPego = scrDetecInteracao.hit.collider.gameObject;
        Item scriptItemPego = gameObjectItemPego.GetComponent<Item>();

        switch (scriptItemPego.nome)
        {
            case "Remedio":
                if (qtdRemedios < 3)
                {
                    qtdRemedios++;
                    AudioItemPego.Play();
                    scriptItemPego.foiPego();
                    AtualizarValoresItens();
                }
                break;

            case "Seringa":
                if (qtdSeringas < 2)
                {
                    Debug.Log("Pegou uma seringa");
                    qtdSeringas++;
                    AudioItemPego.Play();
                    scriptItemPego.foiPego();
                    AtualizarValoresItens();
                }
                break;

            case "Pilha":
                if (qtdBaterias < 2)
                {
                    qtdBaterias++;
                    AudioItemPego.Play();
                    scriptItemPego.foiPego();
                    AtualizarValoresItens();
                }
                break;

            case "Lanterna":
                scrLanterna.Usar();
                AudioItemPego.Play();
                scriptItemPego.foiPego();
                break;

            case "Pe de cabra":
                Debug.Log("Pegou o pé de cabra");
                scrPeDeCabra.Usar();
                AudioItemPego.Play();
                scriptItemPego.foiPego();
                adicionarItemInventario(scriptItemPego);
                break;

            case "Item Totem 1":
            case "Item Totem 2":
            case "Item Totem 3":
                if (UltimoItemTotemPego == null)
                {
                    UltimoItemTotemPego = gameObjectItemPego;
                    AudioItemPego.Play();
                    scriptItemPego.foiPego();
                }
                break;

            case "Chave":
                /*if(!metodoChamado)
                {
                    AtivarTutorial();
                    metodoChamado = true;
                    Invoke("DesativarTutorial", 3f);
                }*/
                UltimaChavePega = gameObjectItemPego;
                AudioItemPego.Play();
                scriptItemPego.foiPego();
                adicionarItemInventario(scriptItemPego);
                
                break;

                   default:                
                       break;
        }

    }

    private void adicionarItemInventario(Item item)
    {
        for(int i = 0; i < inventario.Length; i++) 
        {
            if (inventario[i] == null) 
            {
                inventario[i] = item;
                break;
            }
        }
    }

    private void reorganizarItens()
    {
        for (int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i] == null && inventario[i+1] != null)
            {
                inventario[i] = inventario[i + 1];
                inventario[i + 1] = null;
            }
        }
    }

    public void DesativarTutorial()
    {
        tutorialQuarto.SetActive(false);
        gc.DespausarJogo();
    }

    public void AtivarTutorial()
    {
        tutorialQuarto.SetActive(true);
        gc.PausarJogo();
    }
}
