using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SlotDiario : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text textoDiarioAtual;
    [SerializeField] GameObject slotNoManager;
    [SerializeField] int indiceQualSlotEh;
    public string textoDiario;

    void OnEnable()
    {
        atualizarEstadoSlot();

        if (slotNoManager != null)
        {
            atribuirDadosDoSlot(slotNoManager);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ClicouBotaoEsquerdo();
        }
    }
    private void atribuirDadosDoSlot(GameObject objSlot)
    {
        textoDiario = objSlot.GetComponent<Diario>().textoDiario;
    }
    private void ClicouBotaoEsquerdo()
    {
        textoDiarioAtual.text = textoDiario;
    }
    private void atualizarEstadoSlot()
    {
        DiarioManager scrDiarioManager = GameObject.FindGameObjectWithTag("Diario").GetComponent<DiarioManager>();

       
       
    }
}
