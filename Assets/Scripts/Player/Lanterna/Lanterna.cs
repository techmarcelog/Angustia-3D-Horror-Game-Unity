using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanterna : MonoBehaviour
{
    [Header("Luz")]
    [SerializeField] Light luz;
    [SerializeField] Image crosshair;

    [Header("Estado da Lanterna")]
    [SerializeField] public bool estaLigada;
    [SerializeField] public bool podeLigar;
    [SerializeField] public int baterias;
    [SerializeField] public float tempoDeUsoRestante;
    [SerializeField] float velocidade;
    [SerializeField] Animator AnimLanterna;

    public string NomeCamada = "CamadaIntensidadeLuz";
    private int IndiceCamada;
    float intensidadeDesejada;

    void Awake()
    {
        luz = GetComponent<Light>();
    }

    void Start()
    {
        IndiceCamada = AnimLanterna.GetLayerIndex(NomeCamada);
        Desligar();
        baterias = 0;
        podeLigar = false;
    }

    void Update()
    {
        AnimLanterna.SetFloat("segundosRestantes", tempoDeUsoRestante);
        VerificarTempoRestante();



        if (Input.GetKeyDown(KeyCode.F) && podeLigar)
        {
            if (estaLigada)
            {
                Desligar();
            }
            else
            {
                Ligar();
            }
        }

        if (baterias <= 0)
        {
            baterias = 0;
        }

      
    }


    public void Recarregar()
    {
        podeLigar = true;
       tempoDeUsoRestante = 100;
       
    }

    private void VerificarTempoRestante()
    {
        if (tempoDeUsoRestante <= 0)
        {
            podeLigar = false;
            Desligar();
            tempoDeUsoRestante = 0;
        }

        if (tempoDeUsoRestante >= 100)
        {
            tempoDeUsoRestante = 100;
        }

        if (estaLigada)
        {
            tempoDeUsoRestante -= 1f * Time.deltaTime;
        }
    }

    private void Desligar()
    {
        estaLigada = false;
        luz.enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }

    private void Ligar()
    {
        estaLigada = true;
        luz.enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monstro")
        {
            other.gameObject.GetComponent<ControladorPatrulha>().Perseguir();
        }
    }*/
}
