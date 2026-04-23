using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextos : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextoAtivado;
    [SerializeField] TextMeshProUGUI TextoLanterna;
    [SerializeField] string TextoCollider;
    [SerializeField] string TextoCollider2;
    [SerializeField] Image tutorial;
    public bool ehTutorial2Textos;
    void Start()
    {
        
    }
    void Update()
    {
        if(TextoLanterna != null)
        {
        if(TextoLanterna.enabled)
        {
            TextoAtivado.enabled= false;
        }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ehTutorial2Textos)
            {
                TextoAtivado.text = TextoCollider;
                TextoAtivado.enabled = true;
                Invoke("TrocarTexto", 6f);
                Invoke("DesativarTextoAtivado", 12f);
            }
            else
            {
                TextoAtivado.text = TextoCollider;
                TextoAtivado.enabled = true;
                Invoke("DesativarTextoAtivado", 6f);
            }
        }
    }
    public void TrocarTexto()
    {
        TextoAtivado.enabled = true;
    }
    public void DesativarTextoAtivado()
    {
        TextoAtivado.enabled = false;
        Destroy(this.gameObject);
    }
}
