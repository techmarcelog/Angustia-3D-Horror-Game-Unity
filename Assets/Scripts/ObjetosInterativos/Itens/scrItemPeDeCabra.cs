using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ItemInterativo;

public class scrItemPeDeCabra : Item
{
    public bool equipado = false;
    [SerializeField] TextMeshProUGUI TextoAtivado;
    public override void Start()
    {
        base.Start();
    }

    public override void Usar()
    {
        if(!equipado)
        {
            TextoAtivado.enabled = true;
            base.Usar();
            base.objPlayer.GetComponentInChildren<DetecInteracao>().ObjNaMao = this.gameObject;
            base.objPlayer.GetComponentInChildren<DetecInteracao>().peDeCabraEquipado = true;
            Invoke("DesativarTextoAtivado", 6f);
            equipado = true;
        }
        else
        {
            base.Usar();
            base.objPlayer.GetComponentInChildren<DetecInteracao>().ObjNaMao = null;
            equipado = false;
        }
    }
        public void DesativarTextoAtivado()
        {
            TextoAtivado.enabled = false;
        }
}
