using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ItemInterativo;

public class scrItemLanterna : Item
{
    public bool equipado = false;
    [SerializeField] GameObject ObjLanterna;
    [SerializeField] TextMeshProUGUI TextoAtivado;
    public override void Start()
    {
        base.Start();
    }

    public override void Usar()
    {
        if (!equipado)
        {
            TextoAtivado.enabled = true;
            base.Usar();
            ObjLanterna.GetComponent<Lanterna>().podeLigar = true;
            base.objPlayer.GetComponentInChildren<DetecInteracao>().ObjNaMao = this.gameObject;
            equipado = true;
            Invoke("DesativarTextoAtivado",6f);
            
        }
        else
        {
            base.Usar();
            ObjLanterna.GetComponent<Lanterna>().podeLigar = false;
            base.objPlayer.GetComponentInChildren<DetecInteracao>().ObjNaMao = null;
            equipado = false;
        }
    }
    public void DesativarTextoAtivado()
    {
        TextoAtivado.enabled = false;
    }
}