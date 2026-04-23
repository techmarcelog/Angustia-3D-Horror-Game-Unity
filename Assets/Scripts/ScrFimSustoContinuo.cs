using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ScrFimSustoContinuo : MonoBehaviour
{
    [SerializeField] GameObject MonstroSC;
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource AudioSusto;
    [SerializeField] GameObject LocalRetornoPlayer;
    [SerializeField] GameObject ObjetoInicioSC;
    public PostProcessProfile brilho;
    public PostProcessLayer camada;
    AutoExposure exposicao;
    DetecInteracao scrDetecInteracao;
    // Start is called before the first frame update
    void Start()
    {
        brilho.TryGetSettings(out exposicao);
        scrDetecInteracao = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<DetecInteracao>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scrDetecInteracao.hit.collider != null)
        {
            if (scrDetecInteracao.hit.collider.gameObject != null)
            {
                if (scrDetecInteracao.hit.collider.gameObject.CompareTag("MonstroSC"))
                {
                    AudioSusto.Play();
                    Invoke("Voltar", 1.5f);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MonstroSC.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void Voltar()
    {
        Destroy(ObjetoInicioSC);
        Player.GetComponent<CharacterController>().enabled = false;
        Player.transform.position = LocalRetornoPlayer.transform.position;
        Player.GetComponent<CharacterController>().enabled = true;
        Player.GetComponent<Inventario>().podeAbrir = true;
        Player.GetComponentInChildren<Lanterna>().podeLigar = false;
        Player.GetComponentInChildren<Lanterna>().estaLigada = false;
        exposicao.keyValue.value = 1.0f;
        Destroy(this.gameObject);
    }
}
