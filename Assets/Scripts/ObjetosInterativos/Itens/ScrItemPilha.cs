using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;

public class ScrItemPilha : Item
{
    public override void Start()
    {
        base.Start();
    }

    public override void Usar()
    {
        base.Usar();
        base.objPlayer.GetComponentInChildren<Lanterna>().Recarregar();
    }
}


