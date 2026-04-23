using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotHighlight : MonoBehaviour
{
    [SerializeField] InventarioV2 scriptInventarioV2;
    [SerializeField] public Color corInicial;
    [SerializeField] public Color corApagada;
    [SerializeField] public int indiceNoInventario;
    void Start()
    {
        corInicial = this.gameObject.GetComponent<Image>().color;
        corApagada = new Color(corInicial.r, corInicial.g, corInicial.b, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!scriptInventarioV2.inventarioEstaAberto)
        {
            this.gameObject.GetComponent<Image>().color = corApagada;
            return;
        }
        if (scriptInventarioV2.indiceAtualInventario == indiceNoInventario) this.gameObject.GetComponent<Image>().color = corInicial;
        else this.gameObject.GetComponent<Image>().color = corApagada;
    }
}
