using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiarioManager : MonoBehaviour
{
    [SerializeField]DetecInteracao scrDetecInt;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && scrDetecInt.deteccaoEhUmDiario())
        {
            scrDetecInt.hit.collider.gameObject.GetComponent<ItemPaginaDiario>().foiPego();
        }
    }



}
