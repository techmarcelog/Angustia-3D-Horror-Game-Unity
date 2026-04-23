using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Totem : MonoBehaviour  
{
    [SerializeField] GameObject localItem1;
    [SerializeField] GameObject localItem2;
    [SerializeField] GameObject localItem3;
    [SerializeField] GameObject LuzItem1;
    [SerializeField] GameObject LuzItem2;
    [SerializeField] GameObject LuzItem3;
    [SerializeField] GameObject Item1;
    [SerializeField] GameObject Item2;
    [SerializeField] GameObject Item3;
    [SerializeField] GameObject InstanciaItemTotem1;
    [SerializeField] GameObject InstanciaItemTotem2;
    [SerializeField] GameObject InstanciaItemTotem3;
    [SerializeField] GameObject ImagemFimJogo;


    public bool espacoItem1 = false;
    public bool espacoItem2 = false;
    public bool espacoItem3 = false;
    

    Scene_Manager sceneManager;
    private void Awake()
    {
        sceneManager = GameObject.FindGameObjectWithTag("ScM").GetComponent<Scene_Manager>();
    }

    void Update()
    {
        if(espacoItem1 && espacoItem2 && espacoItem3)
        {
            ImagemFimJogo.SetActive(true);
            Invoke("AcabouOJogo",4f);
        }
        if (InstanciaItemTotem1 == null)
        {
            if (espacoItem1)
            {
                InstanciaItemTotem1 = Instantiate(Item1, localItem1.transform.position, Quaternion.identity);
                InstanciaItemTotem1.transform.localScale = Item1.transform.localScale;
                LuzItem1.SetActive(true);
                InstanciaItemTotem1.SetActive(true);
            }
        }

        if (InstanciaItemTotem2 == null)
        {
            if (espacoItem2)
            {
                InstanciaItemTotem2 = Instantiate(Item2, localItem2.transform.position, Quaternion.identity);
                InstanciaItemTotem2.transform.localScale = Item2.transform.localScale;
                LuzItem2.SetActive(true);
                InstanciaItemTotem2.SetActive(true);
            }
        }
        if (InstanciaItemTotem3 == null)
        {
            if (espacoItem3)
            {
                InstanciaItemTotem3 = Instantiate(Item3, localItem3.transform.position, Quaternion.identity);
                InstanciaItemTotem3.transform.localScale = Item3.transform.localScale;
                LuzItem3.SetActive(true);
                InstanciaItemTotem3.SetActive(true);
            }
        }
    }
    public void AcabouOJogo()
    {
        sceneManager.SairDoJogo();
    }
}
