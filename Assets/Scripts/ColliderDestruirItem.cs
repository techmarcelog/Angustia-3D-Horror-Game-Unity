using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestruirItem : MonoBehaviour
{
    public GameObject parametro;
    public bool podeDestruir;
    public bool tacolidino;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        tacolidino = true;
        Debug.Log(other.gameObject.name);
        if(other != null)
        {
            Debug.Log("AAAAAAAAAFIOGFYOIAIOFHAHI´F");
        parametro = other.gameObject;
        }
        if(podeDestruir)
        {
            Destroy(other.gameObject);
            podeDestruir = false;
        }
        
    }
}
