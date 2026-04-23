using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LanternaHighlight : MonoBehaviour
{
    [SerializeField] Lanterna scriptLanterna;
    [SerializeField] InventarioV2 scriptInventarioV2;
    [SerializeField] Color corInicial;
    [SerializeField] Color corApagada;
    [SerializeField] Color corIconeInicial;
    [SerializeField] Color corIconeApagada;
    [SerializeField] int indiceNoInventario;
    [SerializeField] GameObject objIconeDaLanterna;
    
    void Start()
    {
        Debug.Log("StopPlayinThemRiot");
        corInicial = this.gameObject.GetComponent<Image>().color;
        corApagada = new Color(corInicial.r, corInicial.g, corInicial.b, 0.3f);
        corIconeInicial = objIconeDaLanterna.GetComponent<Image>().color;
        corIconeApagada = new Color(corIconeInicial.r, corIconeInicial.g, corIconeInicial.b, 0.3f); 
        objIconeDaLanterna.SetActive(scriptInventarioV2.scrLanterna.equipado);
        this.gameObject.GetComponent<Image>().color = corApagada;

    }

    void Update()
    {
        if(!scriptInventarioV2.scrLanterna.equipado)
        {
            this.gameObject.GetComponent<Image>().color = corApagada;            
        }

        objIconeDaLanterna.SetActive(scriptInventarioV2.scrLanterna.equipado);

        if (!scriptLanterna.estaLigada)
        {
            this.gameObject.GetComponent<Image>().color = corApagada;
            objIconeDaLanterna.GetComponent<Image>().color = corIconeApagada;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = corInicial;
            objIconeDaLanterna.GetComponent<Image>().color = corIconeInicial;
        }
    }
}
