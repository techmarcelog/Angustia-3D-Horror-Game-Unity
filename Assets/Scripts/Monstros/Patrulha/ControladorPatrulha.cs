using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorPatrulha : MonoBehaviour
{
    public Transform[] waypoints;
    private int waypointAtual;
    public Vector3 alvo;

    public GameObject Player;
    public GameObject JumpCam;
    public GameObject PlayerCam;
    public GameObject FlashImg;
    public GameObject MonstroA1;
    public GameObject MonstroA2;
    public int QualMonstroEh;

    bool JumpAcontecendo;


    private Transform player;

    public float velPatrulha = 2f;
    public float velPerseguicao = 5f;
    private bool perseguindo;
    [SerializeField] Animator animMonstro;


    private NavMeshAgent agent;

    CampoDeVisao visao;

    [SerializeField] AudioSource AudioMonstroPerseguindo;
    [SerializeField] AudioSource AudioMonstroRondando;
    [SerializeField] AudioSource AudioJumpscare;

    [SerializeField] GameObject ColliderCostas;


    void Start()
    {
        waypointAtual = 0;
        perseguindo = false;
        visao = GetComponent<CampoDeVisao>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        DefinirDestinoPatrulha();
    }

    void Update()
    {
        animMonstro.SetBool("perseguindo", perseguindo);
        animMonstro.SetFloat("velocidade", agent.speed);
        if (visao.podeVerPlayer || ColliderCostas.GetComponent<ColliderCostasMonstro>().podeVerPlayerCostas) 
        {
            Perseguir();
            AudioMonstroPerseguindo.enabled = true;
            AudioMonstroRondando.enabled = false;
        }
        else
        {
            perseguindo = false;
            PararPerseguir();
            AudioMonstroPerseguindo.enabled = false;
            AudioMonstroRondando.enabled = true;
        }
        if (!perseguindo && Vector3.Distance(transform.position, alvo) < 1)
        {
            DefinirDestinoPatrulha();
            ProximoWaypoint();
        }
    }

    public void Perseguir()
    {
        perseguindo = true;
        agent.speed = velPerseguicao;
        agent.speed = velPerseguicao;
        agent.SetDestination(player.position);
    }
    private void PararPerseguir()
    {
        perseguindo = false;
        DefinirDestinoPatrulha();
    }

    private void ProximoWaypoint()
    {
        waypointAtual++;
        if (waypointAtual == waypoints.Length) //quando chegar no ultimo waypoint, reiniciar
        {
            waypointAtual = 0;
        }
    }
    private void DefinirDestinoPatrulha()
    {
        agent.speed = velPatrulha;
        alvo = waypoints[waypointAtual].position;
        agent.SetDestination(alvo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (QualMonstroEh == 1)
            {
                MonstroA2.SetActive(false);
                MonstroA1.SetActive(true);
                JumpCam.SetActive(true);
                PlayerCam.SetActive(false);
                FlashImg.SetActive(true);
                AudioJumpscare.Play();
                StartCoroutine(FimJump());
            }
            if (QualMonstroEh == 2)
            {
                MonstroA1.SetActive(false);
                MonstroA2.SetActive(true);
                JumpCam.SetActive(true);
                PlayerCam.SetActive(false);
                FlashImg.SetActive(true);
                AudioJumpscare.Play();
                StartCoroutine(FimJump());
            }
        }
    }
    IEnumerator FimJump()
    {
        yield return new WaitForSeconds(2.03f);
        PlayerCam.SetActive(true);
        JumpCam.SetActive(false);
        FlashImg.SetActive(false);
        Player.gameObject.GetComponent<PlayerController>().Morreu();
    }

}