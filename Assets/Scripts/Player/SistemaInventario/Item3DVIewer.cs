using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Item3DVIewer : MonoBehaviour, IDragHandler {

    [SerializeField] private Slot slot;
    public GameObject modeloInstancia;
   [SerializeField] public GameObject localInstancia;
    private GameObject itemPrefab;
    void Start()
    {
        modeloInstancia = slot.modelo3DItemAtual;
    }

    public void ItemSelecionado()
    {
 
        if(itemPrefab != null)
        {
            Destroy(itemPrefab.gameObject);
        }

        itemPrefab = Instantiate(modeloInstancia,localInstancia.transform.position,Quaternion.identity);
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemPrefab.transform.eulerAngles += new Vector3(-eventData.delta.x, -eventData.delta.y);
    }
}
