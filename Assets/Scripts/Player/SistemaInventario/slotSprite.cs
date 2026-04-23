using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class slotSprite : MonoBehaviour
{
    [SerializeField] InventarioV2 scriptInventarioV2;
    [SerializeField] GameObject objFilho;

    [SerializeField] Sprite spritePeDeCabra;
    [SerializeField] Sprite spriteChave;
    int indiceNoInventario;

    void Start()
    {        
        indiceNoInventario = GetComponent<slotHighlight>().indiceNoInventario;
        objFilho.GetComponent<Image>().color = this.gameObject.GetComponent<Image>().color;


    }

    void Update(){
        MudarSprite();
        objFilho.GetComponent<Image>().color = this.gameObject.GetComponent<Image>().color;
    }

    private void MudarSprite()
    {

        if(scriptInventarioV2.inventario[indiceNoInventario] == null){
            objFilho.SetActive(false);
            return;
        }
        else objFilho.SetActive(true);

        switch (scriptInventarioV2.inventario[indiceNoInventario].nome)
        {
            case "Pe de cabra":
            objFilho.GetComponent<Image>().sprite = spritePeDeCabra;
            break;
            case "Chave":
            objFilho.GetComponent<Image>().sprite = spriteChave;
            break;
            
            default:
            break;
        }
    }
}
