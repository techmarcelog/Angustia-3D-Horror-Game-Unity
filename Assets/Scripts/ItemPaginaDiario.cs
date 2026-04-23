using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPaginaDiario : MonoBehaviour
{
    [SerializeField] Diario scrDiario;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void foiPego()
    {
        scrDiario.bloqueado = false;
        this.gameObject.SetActive(false);
    }
}
