using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;

public class scrItem_Chave : Item
{
    [SerializeField] int numeroChave;

    public override void Start()
    {
        base.Start();
    }

    public override void Usar()
    {
        base.Usar();
        if (base.objPlayer.GetComponentInChildren<DetecInteracao>().hit.transform.gameObject.GetComponent<SistemaPorta>().precisaDeChave)
        {
            if (base.objPlayer.GetComponentInChildren<DetecInteracao>().hit.transform.gameObject.GetComponent<SistemaPorta>().qualChavePrecisa == numeroChave)
            {
                base.objPlayer.GetComponentInChildren<DetecInteracao>().hit.transform.gameObject.GetComponent<SistemaPorta>().estaTrancada = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
      //  if (collision.collider.CompareTag("Player")) Debug.Log("Fuckin shit bro");
    }
}
