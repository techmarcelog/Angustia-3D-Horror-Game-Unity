using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using ItemInterativo;
public class Slot : MonoBehaviour, IPointerClickHandler //detecta click do mouse 
{
    [Header("Dados Slot")]
    [SerializeField] Transform posicaoInstanciaDaImagem;
    [SerializeField] GameObject slotNoInventario;
    Seringa scrSeringa;
    [SerializeField] int indiceQualSlotEh;
    [SerializeField] bool espacoFoiPreenchido;
    [SerializeField] bool slotEhGrande;

    public Sprite sprite2D;
        

    [Header("Dados Item")]
    public Item scriptItem;

    public string nomeItem;
    public string descricao;
    public Sprite sprite2DView;
    

    public GameObject modelo3DItemAtual;
    public GameObject modelo3D;

    [Header("Texto Gráfico")]
    public TMP_Text textoNomeItemAtual;
    public TMP_Text textoDescricaoItemAtual;
    public GameObject slotPrefab;
    [SerializeField] public Image imagemView;
    GameObject imagemItemCanvas;

    [SerializeField] Item3DVIewer scrItem3dViewer;
    [SerializeField] public GameObject localInstancia;
    private GameObject itemPrefab;
    

    ColliderDestruirItem scrDestruirItem;

    void Awake()
    {
        textoNomeItemAtual = GameObject.FindGameObjectWithTag("textoNomeItem_Inventario").GetComponent<TMP_Text>();
        textoDescricaoItemAtual = GameObject.FindGameObjectWithTag("textoDescricaoItem_Inventario").GetComponent<TMP_Text>();
        modelo3DItemAtual = GameObject.FindGameObjectWithTag("item_viewer_3d");
        posicaoInstanciaDaImagem = this.gameObject.GetComponent<RectTransform>().transform;
    }

    void OnEnable()
    {        
        atualizarEstadoSlot();

        if (slotNoInventario != null)
        {
            atribuirDadosDoSlot(slotNoInventario);
            if (!espacoFoiPreenchido)
            {
                AdicionarSprite(sprite2D);
                espacoFoiPreenchido = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ClicouBotaoEsquerdo();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            ClicouBotaoDireito();
        }
    }

    private void atribuirDadosDoSlot(GameObject objSlot)
    {
        nomeItem = objSlot.GetComponent<Item>().nome;
        sprite2D = objSlot.GetComponent<Item>().spriteInventario;
        descricao = objSlot.GetComponent<Item>().descricao;
        modelo3D = objSlot.GetComponent<Item>().modelo3dJogo;
            
    }

    private void atualizarEstadoSlot()
    {
        Inventario scriptInventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();

        if (slotEhGrande)
        {
            slotNoInventario = scriptInventario.slotsGrandes[indiceQualSlotEh];
        }
        else
        {
            slotNoInventario = scriptInventario.slotsPequenos[indiceQualSlotEh];
        }
    }

    public void ClicouBotaoEsquerdo()
    {
        textoNomeItemAtual.text = nomeItem;
        textoDescricaoItemAtual.text = descricao;
        imagemView.enabled = true;
        imagemView.sprite = sprite2D;
        modelo3DItemAtual = modelo3D;
        if(sprite2D == null)
        {
            imagemView.enabled = false;
        }
    }

    private void ClicouBotaoDireito()
    {
        if (imagemItemCanvas == null) return;

        slotNoInventario.GetComponent<Item>().Usar();
         apagar_ItemNoSlot();        
    }

    private void apagar_ItemNoSlot()
    {
        Inventario scriptInventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();

        if (slotEhGrande)
        {
            scriptInventario.apagarItemGrande(indiceQualSlotEh);
            nomeItem = string.Empty;
            descricao = string.Empty;
            sprite2D = null;
            modelo3D = null;
            imagemView.enabled = false;
            textoNomeItemAtual.text = string.Empty;
            textoDescricaoItemAtual.text = string.Empty;
            espacoFoiPreenchido = false;
            removerSprite();

        }
        if (!slotEhGrande)
        {
            scriptInventario.apagarItemPequeno(indiceQualSlotEh);
            nomeItem = string.Empty;
            descricao = string.Empty;
            sprite2D = null;
            modelo3D = null;
            imagemView.enabled = false;
            textoNomeItemAtual.text = string.Empty;
            textoDescricaoItemAtual.text = string.Empty;
            espacoFoiPreenchido = false;
            removerSprite();
        }
    }

    private void removerSprite()
    {        
        Destroy(imagemItemCanvas);
        Destroy(modelo3D);
        slotNoInventario= null;
    }

    private void AdicionarSprite(Sprite itemSprite)
    {
        slotPrefab.GetComponent<Image>().sprite = itemSprite;
        slotPrefab.GetComponent<Image>().color = Color.white;
        imagemItemCanvas = Instantiate(slotPrefab, posicaoInstanciaDaImagem, false);
    }


}
