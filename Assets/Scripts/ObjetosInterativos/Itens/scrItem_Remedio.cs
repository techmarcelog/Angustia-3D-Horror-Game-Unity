using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;

public class scrItem_Remedio : Item
{

    public override void Usar()
    {
        base.Usar();    
        base.objPlayer.GetComponent<Sanidade>().AdicionarSanidade(15);
    }
}
