using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetecInteracao : MonoBehaviour
{
    [SerializeField] string debug;

    [SerializeField] LayerMask camadaDeChecagemDeObj;
    [SerializeField] LayerMask camadaDeChecagemDeObjItensMao;
    [SerializeField] public bool objFoiDetectado = false;
    //[SerializeField] public bool objFoiDetectadoMao = false;
    [SerializeField] public bool detectarPaciente = false;
    [SerializeField] Image crosshairPegarItem;
    [SerializeField] Image crosshairPorta;
    [SerializeField] Image crosshairTrancada;
    public bool peDeCabraEquipado = false;

    [SerializeField] GameObject Mao;
    public GameObject ObjNaMao;
    GameObject InstanciaObjNaMao;
    public RaycastHit hit;

    

    private void Start()
    {        
        Physics.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("Player"), true);
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteragirPorta();
            InteragirGaveta();
            InteragirPeDeCabra();
        }
        DetectarObjeto();
        TrocarCrosshairPegarItem();
    }

    void DetectarObjeto()
    {
        int layerMask = (1 << LayerMask.NameToLayer("Interativo")) | (1 << LayerMask.NameToLayer("Chao"));
         Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.5f, layerMask);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
        
        if(hit.transform != null)
        objFoiDetectado = LayerMask.LayerToName(hit.collider.gameObject.layer) == "Interativo";

    }
    
    public bool deteccaoEhUmItem()
    {
        if (hit.collider == null) return false;


        if (hit.collider.gameObject.CompareTag("Item"))
        {
            Debug.Log(hit.collider.gameObject.name);
             return true;            
        }
        return false;
    }

    public bool deteccaoEhUmDiario()
    {
        if (hit.collider == null) return false;


        if (hit.collider.gameObject.CompareTag("Diario"))
        {
            return true;
        }
        return false;
    }


    

    public bool CompararComDeteccao(GameObject objDeComparacao)
    {
        if (!objFoiDetectado) return false;

        if (hit.collider.gameObject == objDeComparacao)
        {
            return true;
        }

        return false;
    }

    public void InteragirPorta()
    {
        if (hit.collider == null)
        {
            return;
        }
        else if (hit.collider.gameObject.CompareTag("Porta"))
        {
            SistemaPorta scriptDaPorta = hit.collider.transform.GetComponent<SistemaPorta>();
            if (!scriptDaPorta.estaAberta)
            {
                scriptDaPorta.abrirPorta();
            }
            else
            {
                scriptDaPorta.fecharPorta();
            }
        }
    }
       public void InteragirPeDeCabra()
    {
        if(peDeCabraEquipado && hit.collider.gameObject.CompareTag("PassagemPeDeCabra"))
        {
            Destroy(hit.collider.gameObject);
        }
    }
    public void InteragirGaveta()
    {
        if (hit.collider == null) return;   
        else if (hit.collider.gameObject.CompareTag("Gaveta"))
        {
            SistGaveta scriptDaGaveta = hit.collider.transform.GetComponent<SistGaveta>();
            Debug.Log("Tentou abrir");
            if (!scriptDaGaveta.estaAberta)
            {
                scriptDaGaveta.abrirGaveta();
            }
            else
            {
                scriptDaGaveta.fecharGaveta();
            }
        }
    }
    public void TrocarCrosshairPegarItem()
    { if(hit.collider == null)
        {
            crosshairPegarItem.enabled = false;
            crosshairPorta.enabled = false;
            crosshairTrancada.enabled = false;
            return;
        }
      if( hit.collider.gameObject == null || hit.collider.gameObject.tag != "Item" && hit.collider.gameObject.tag != "Porta" && hit.collider.gameObject.tag != "Gaveta" && hit.collider.gameObject.tag !=("Diario") && hit.collider.gameObject.tag != ("PassagemPeDeCabra"))
        {
            crosshairPegarItem.enabled = false;
            crosshairPorta.enabled = false;
            crosshairTrancada.enabled = false;
          
        }
      else if (hit.collider.gameObject.CompareTag("Item") || hit.collider.gameObject.CompareTag("Diario"))
        {
            crosshairPegarItem.enabled = true;
            crosshairPorta.enabled = false;
            crosshairTrancada.enabled = false;
        }
      else if (hit.collider.gameObject.CompareTag("Porta") && hit.collider.gameObject.GetComponent<SistemaPorta>().estaTrancada == false || hit.collider.gameObject.CompareTag("Gaveta"))
        {
            crosshairPorta.enabled = true;
            crosshairTrancada.enabled = false;
            crosshairPegarItem.enabled = false;
        }
       else if(hit.collider.gameObject.CompareTag("Porta") && hit.collider.gameObject.GetComponent<SistemaPorta>().estaTrancada == true || hit.collider.gameObject.CompareTag("PassagemPeDeCabra"))
        {
            crosshairTrancada.enabled = true;
            crosshairPorta.enabled = false;
            crosshairPegarItem.enabled = false;
        }
    }
}

