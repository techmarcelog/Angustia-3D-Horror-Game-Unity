using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SustoContinuo : MonoBehaviour
{
    [SerializeField] GameObject localInstanciaPlayer;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject ImagemTransicao;
    public PostProcessProfile brilho;
    public PostProcessLayer camada;
    AutoExposure exposicao;
    // Start is called before the first frame update
    void Start()
    {
        brilho.TryGetSettings(out exposicao);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player.GetComponent<Inventario>().podeAbrir = false;
            exposicao.keyValue.value = 0.3f;
            ImagemTransicao.SetActive(true);
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = localInstanciaPlayer.transform.position;
            other.transform.rotation = Quaternion.identity;
            other.GetComponent<CharacterController>().enabled = true;
            other.GetComponentInChildren<Lanterna>().podeLigar = false;
            other.GetComponentInChildren<Lanterna>().estaLigada = false;
            Invoke("DesativarImagem", 4f);
            Debug.Log("Era pra ir \n Player pos " + other.transform.position.ToString() + " Local Pos " + localInstanciaPlayer.transform.position.ToString());
            
        }
    }
    private void DesativarImagem()
    {
        ImagemTransicao.SetActive(false);
    }
}
