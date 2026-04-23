using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;

public class scrItem_Seringa : Item
{
    public override void Start()
    {
        base.Start();
    }

    public override void Usar()
    {
        base.Usar();
        base.objPlayer.GetComponent<Sanidade>().AdicionarSanidade(30);
        Debug.Log(base.objPlayer.GetComponent<Sanidade>());
    }
}
