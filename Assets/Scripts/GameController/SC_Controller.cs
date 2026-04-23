using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Controller : MonoBehaviour
{
    [SerializeField] GameObject[] corredores;
    [SerializeField] GameObject[] triggers;
    [SerializeField] GameObject[] luzes;
    GameObject aa;

    int corredorAtual = 0;
    int luzAtual = 0;
    int luzAnterior;

    private void Start()
    {

        for (int i = 1; i < corredores.Length; i++)
        {
            corredores[i].SetActive(false);
        }
        for (int i = 1; i < triggers.Length; i++)
        {
            triggers[i].SetActive(false);
        }
        for (int i = 0; i < luzes.Length; i++)
        {
            luzes[i].SetActive(false);
        }
    }
    void Update()
    {
        luzAnterior = luzAtual - 1;
     /*   Debug.Log("Luz atual " + luzAtual);
        Debug.Log("Luz para apagar " + luzAnterior);*/
    }

    public void DiminuirCorredor()
    {
        Destroy(corredores[corredorAtual]);
        Destroy(triggers[corredorAtual]);
        corredorAtual++;
        corredores[corredorAtual].SetActive(true);
        triggers[corredorAtual].SetActive(true);
    }

    public void MudarLuz()
    {
        if (luzAtual < 5)
        {
            Destroy(luzes[luzAtual]);
            luzAtual++;
            luzes[luzAtual].SetActive(true);
        }
        else if(luzAtual == 5)
        {
            luzes[5].SetActive(true);
            luzes[6].SetActive(true);
            luzes[7].SetActive(true);
            luzes[8].SetActive(true);
        }
    }
}
