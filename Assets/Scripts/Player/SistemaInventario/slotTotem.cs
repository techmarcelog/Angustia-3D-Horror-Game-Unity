using ItemInterativo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotTotem : MonoBehaviour
{

    [SerializeField] InventarioV2 scriptInventarioV2;
    [SerializeField] GameObject objFilho;

    [SerializeField] Color corInicial;
    [SerializeField] Color corApagada;

    [SerializeField] Sprite spriteItemTotem1;
    [SerializeField] Sprite spriteItemTotem2;
    [SerializeField] Sprite spriteItemTotem3;

    void Start()
    {
        objFilho.GetComponent<Image>().color = this.gameObject.GetComponent<Image>().color;
        corInicial = this.gameObject.GetComponent<Image>().color;
        corApagada = new Color(corInicial.r, corInicial.g, corInicial.b, 0.3f);
    }

    void Update()
    {
        MudarSprite();
        objFilho.GetComponent<Image>().color = this.gameObject.GetComponent<Image>().color;
    }

    private void MudarSprite()
    {

        if (scriptInventarioV2.UltimoItemTotemPego == null)
        {
            this.gameObject.GetComponent<Image>().color = corApagada;
            objFilho.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = corInicial;
            Debug.Log("Tem um item de totem");
            objFilho.SetActive(true);
        }

        switch (scriptInventarioV2.UltimoItemTotemPego.GetComponent<Item>().nome)
        {
            case "Item Totem 1":
                
                objFilho.GetComponent<Image>().sprite = spriteItemTotem1;
                break;

            case "Item Totem 2":
                Debug.Log("Pegou o item 2 ^^");
                objFilho.GetComponent<Image>().sprite = spriteItemTotem2;
                break;

            case "Item Totem 3":
                objFilho.GetComponent<Image>().sprite = spriteItemTotem3;
                break;

            default:
                break;
        }
    }
}
