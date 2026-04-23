using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemInterativo;
public class Inventario : MonoBehaviour
{

    /*
     
     FAZER O DROPPING DPS

    QUANDO FOR FAZER O VISUAL DO INVENTARIO FAZER A ATRIBUICAO DA IMG DO NOVO ITEM quando for pegar
     */

    public bool estaAberto = false;

    [Header("PROPRIEDADES SLOTS")]
    [SerializeField] public GameObject[] slotsGrandes = new GameObject[3];
    [SerializeField] public GameObject[] slotsPequenos = new GameObject[4];
    [SerializeField] public Transform[] posicaoSlots;
    [SerializeField] public GameObject preFabSlots;
    [SerializeField] GameObject itemPego;

    [Header("PROPRIEDADES ABAS")]
    [SerializeField] public GameObject abaInventario;
    [SerializeField] public GameObject abaDiario;
    [SerializeField] public GameObject menu;
    [SerializeField] public CanvasGroup imgVida;
    [SerializeField] public CanvasGroup imgSanidade;

    [Header("PROPRIEDADES ULTIMO ITEM PEGO ITEM")]
    public Sprite spriteUltimoItemPego;
    public string nomeUltimoItemPego;
    public string descricaoUltimoItemPego;

    Camera scriptCamera;
    DetecInteracao scriptDetecInteracao;
    gameController scriptGameController;
    PlayerController scriptPlayerController;
    Sanidade scriptSanidade;

    [SerializeField] AudioSource AudioInventarioAbrir;
    [SerializeField] AudioSource AudioInventarioFechar;
    [SerializeField] AudioSource AudioItemPego;

    public bool estaCheioG = false;
    public bool estaCheioP = false;
    public bool podeAbrir = true;

    void Awake()
    {
        scriptCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        scriptDetecInteracao = this.GetComponentInChildren<DetecInteracao>();
        scriptGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
        scriptPlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        scriptSanidade = GameObject.FindGameObjectWithTag("Player").GetComponent<Sanidade>();
    }

    void Update()
    {
      /* VerificarItemCheioG();
        VerificarItemCheioP();
        imgVida.alpha = scriptPlayerController.vida / 75.0f;
        imgSanidade.alpha = scriptSanidade.quantidadeSanidade / 100.0f;*/
        if (Input.GetKeyDown(KeyCode.LeftAlt)&& podeAbrir)
        {
            if (estaAberto)
            {
                FecharInventario();
                AudioInventarioFechar.Play();
            }
            else if(scriptGameController.pausado == false)
            {
                AbrirInventario();
                AbrirAbaDiario();
                AudioInventarioAbrir.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
          /*  if (scriptDetecInteracao.deteccaoEhUmItem())
            {
                if (!estaCheioG)
                {

                    gameObjectItemPego = scriptDetecInteracao.hit.collider.gameObject;

                    Item scriptItemPego = gameObjectItemPego.GetComponent<Item>();
                    if (scriptItemPego.ehUmItemGrande())
                    {
                        GuardarNoInventario(slotsGrandes);
                    nomeUltimoItemPego = scriptItemPego.qualItem.ToString();
                    descricaoUltimoItemPego = scriptItemPego.descricao;
                    spriteUltimoItemPego = scriptItemPego.spriteInventario;
                    scriptItemPego.foiPego();
                    AudioItemPego.Play();
                    }
                }
                if (!estaCheioP)
                { 
                    gameObjectItemPego = scriptDetecInteracao.hit.collider.gameObject;

                    Item scriptItemPego = gameObjectItemPego.GetComponent<Item>();
                    if(scriptItemPego.ehUmItemGrande())
                    {
                        return;
                    }
                    else
                    {
                        GuardarNoInventario(slotsPequenos);
                    nomeUltimoItemPego = scriptItemPego.qualItem.ToString();
                    descricaoUltimoItemPego = scriptItemPego.descricao;
                    spriteUltimoItemPego = scriptItemPego.spriteInventario;
                    scriptItemPego.foiPego();
                    AudioItemPego.Play();
                    }
                }               
               
            }*/
        }
    }

    private void GuardarNoInventario(GameObject[] tipoSlots)
    {
        for (int i = 0; i < tipoSlots.Length; i++)
        {
            if (tipoSlots[i] == null)
            {
                tipoSlots[i] = itemPego;

                break;
            }
        }
    }

        private void VerificarItemCheioG()
        {
                for (int i = 0; i < slotsGrandes.Length; i++)
                {
                    if (slotsGrandes[i] == null)
                    {
                    estaCheioG = false;
                        break;
                    }
                else
                {
                    estaCheioG = true;
                }
            
             }

        }
    private void VerificarItemCheioP()
    {
        for (int i = 0; i < slotsPequenos.Length; i++)
        {
            if (slotsPequenos[i] == null)
            {
                estaCheioP = false;
                break;
            }
            else
            {
                estaCheioP = true;
            }

        }

    }

    private void AbrirInventario()
    {
        estaAberto = true;
        scriptGameController.PausarJogo();
        menu.SetActive(true);
    }

    private void FecharInventario()
    {
        estaAberto = false;
        scriptGameController.DespausarJogo();
        menu.SetActive(false);
    }

    public void apagarItemGrande(int indiceItem)
    {
        if (indiceItem > (slotsGrandes.Length - 1)) return;

        slotsGrandes[indiceItem] = null;
    }

    public void apagarItemPequeno(int indiceItem)
    {
        if (indiceItem > (slotsPequenos.Length - 1)) return;

        slotsPequenos[indiceItem] = null;
    }

    public void AbrirAbaDiario()
    {
        abaDiario.SetActive(true);
        abaInventario.SetActive(false);
    }

    public void AbrirAbaInventario()
    {
        abaDiario.SetActive(false);
        abaInventario.SetActive(true);
    }
}
