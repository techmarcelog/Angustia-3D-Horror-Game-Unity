using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuracao : MonoBehaviour
{
    public bool abertoConfig; 
    gameController gc;
    Inventario inv;
    [SerializeField] GameObject painelConfig;
    [SerializeField] GameObject painelControles;
    [SerializeField] GameObject painelAjustes;
    [SerializeField] GameObject painelSair;
    [SerializeField] GameObject painelTutorial;
    [SerializeField] GameObject painelExplicacao;
    [SerializeField] GameObject[] linhas = new GameObject[3];


    void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameController>();
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!inv.estaAberto)
            AbrirConfig();
        }
    }

    void AbrirConfig()
    {

        if (!abertoConfig)
        {
            abertoConfig = true;
            gc.PausarJogo();
            painelConfig.SetActive(true);
            Debug.Log("Abriu config");
        }

    }

    public void Continuar()
    {
        abertoConfig = false;
        gc.DespausarJogo();
        painelConfig.SetActive(false);
        linhas[0].SetActive(false);
    }
    public void TelaControles()
    {
        painelControles.SetActive(true);
        painelConfig.SetActive(false);
    }

    public void TelaAjustes()
    {
        painelAjustes.SetActive(true);
        painelConfig.SetActive(false);
    }
    public void VoltarConfig()
    {
        painelConfig.SetActive(true);
        painelControles.SetActive(false);
        painelAjustes.SetActive(false);
        painelSair.SetActive(false);
        linhas[1].SetActive(false);
        linhas[2].SetActive(false);
        linhas[3].SetActive(false);
    }

    public void TelaSair()
    {
        painelSair.SetActive(true);
        painelConfig.SetActive(false);
    }

    public void Tutorial()
    {
        painelExplicacao.SetActive(true);
        painelTutorial.SetActive(false);
    }

    public void IniciarJogo()
    {
        painelTutorial.SetActive(false);
        painelExplicacao.SetActive(false);
        Time.timeScale = 1f;
        abertoConfig = false;
    }

}
