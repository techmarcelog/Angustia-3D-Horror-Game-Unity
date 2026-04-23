using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisaoLuz : MonoBehaviour
{
    RaycastHit raioDaLanterna;
    [SerializeField] bool estaDetectandoMonstro;
    int camadasDeDeteccao;

    private void Start()
    {
        
    }
    private void Update()
    {
        camadasDeDeteccao = (1 << LayerMask.NameToLayer("Monstro")) | (1 << LayerMask.NameToLayer("Chao"));
        Physics.Raycast(transform.position, Vector3.forward,out raioDaLanterna, 15f, camadasDeDeteccao);
        estaDetectandoMonstro = LayerMask.LayerToName(raioDaLanterna.collider.gameObject.layer) == "Monstro";
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
