using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Diario : MonoBehaviour
{
    [SerializeField] DiarioManager manager;
    [SerializeField] public int pageIndex;
    [SerializeField] public string textoDiario;
    [SerializeField] public bool bloqueado;
    [SerializeField] TMP_Text txtDiario;
    [SerializeField] TMP_Text txtInterrog;
    [SerializeField] string txtNumeroPag;
    [SerializeField] Image imagemBloq;

    private void Update()
    {
        if (!bloqueado)
        {
            imagemBloq.enabled = false;
            txtInterrog.text = txtNumeroPag;
        }
    }

    public void Clicou()
    {
        if (!bloqueado)
        {
            txtDiario.text = textoDiario;
            
        }
    }
}
