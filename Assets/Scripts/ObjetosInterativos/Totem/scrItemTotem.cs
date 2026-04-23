using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;

public class scrItemTotem : Item
{
    [SerializeField] int numeroItem;

    public override void Start()
    {
        base.Start();
    }

    public override void Usar()
    {
        base.Usar();
        if (numeroItem == 1)
        {
            base.objPlayer.GetComponentInChildren<DetecInteracao>().hit.transform.gameObject.GetComponent<Totem>().espacoItem1 = true;
        }
        if (numeroItem == 2)
        {
            base.objPlayer.GetComponentInChildren<DetecInteracao>().hit.transform.gameObject.GetComponent<Totem>().espacoItem2 = true;
        }
        if (numeroItem == 3)
        {
            base.objPlayer.GetComponentInChildren<DetecInteracao>().hit.transform.gameObject.GetComponent<Totem>().espacoItem3 = true;
        }
    }
}
