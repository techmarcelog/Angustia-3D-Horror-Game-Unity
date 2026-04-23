using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterativo;

public class scrDeteccaoChaveNaPorta : MonoBehaviour
{      
    private string senhaID = "AB";
    public bool tentarDestravarPorta(string senhaID)
    {
        if (senhaID == this.senhaID)
        {
            this.gameObject.GetComponent<SistemaPorta>().abrirPorta();
            return true;
        }
        return false;
    }


}
