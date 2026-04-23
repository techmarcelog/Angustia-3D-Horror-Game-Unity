using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimentacao : MonoBehaviour
{

    [Header("Movimentação")]
    [SerializeField] public AudioSource audioAndando;
    [SerializeField] public AudioSource audioCorrendo;
    [SerializeField] public AudioSource audioCorrendo2;
    [SerializeField] private float vel;
    public float velAndando;
    public float velCorrendo;
    private bool andando = false;
    private bool correndo = false;
    private Vector3 move;

    private Camera playerCamera;
    public CharacterController controller;

    

    [Header("Gravidade")]
    public float gravidade = -9.81f;
    Vector3 velocidade;


    [Header("Verificar se está no chão")]
    public Transform pe;
    public LayerMask camadaChao;
    public bool noChao;
    public float raioPe = 0.4f;

    [Header("Agachar")]
    public float velAgachado;
    public float escalaYAgachado;
    private float escalaYPadrao;
    private bool agachado = false;
    public bool podeTeclar_Agachar = true;

    [Header("Head Bob")]
    Headbob scriptHeadbob;


    public estadoPlayer estado;
    public enum estadoPlayer
    {
        andando, agachando, correndo
    }

    public void MudarEstado()
    {
        if(estado != estadoPlayer.agachando && Input.GetKeyDown(KeyCode.LeftShift))
        {
             if (noChao && Input.GetKey(KeyCode.LeftShift))
          {
            DefinirNovoEstado(estadoPlayer.correndo);  
         }
        }
        else if(noChao)
        {
            DefinirNovoEstado(estadoPlayer.andando);
        }
        if(Input.GetKey(KeyCode.LeftControl) && podeTeclar_Agachar)
        {
            DefinirNovoEstado(estadoPlayer.agachando);
        }
    }
    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        escalaYPadrao = transform.localScale.y;
      //  cameraYpos = playerCamera.transform.localPosition.y;
        podeTeclar_Agachar = true;

        if (GetComponentInChildren<Headbob>() != null)
            scriptHeadbob = GetComponentInChildren<Headbob>();
        else
            scriptHeadbob = new Headbob();
    }

    void Update()
    {
        noChao = Physics.CheckSphere(pe.position, raioPe, camadaChao);

        MudarEstado();
        Andar();
        Gravidade();
       
       // Debug.Log("Velocidade Player: " + controller.velocity.magnitude);
     /*   #region Definir Velocidade headbob        
        switch (estado)
        {
            case estadoPlayer.andando:
                
                if (transform.localScale.y == escalaYPadrao)
                    scriptHeadbob.alturaAtual = scriptHeadbob.get_alturaInicial();
                scriptHeadbob.velocidade = transform.localScale.y < escalaYPadrao? 2f : scriptHeadbob.velocidadeComum;
                break;

            case estadoPlayer.agachando:
                if (transform.localScale.y == escalaYAgachado)
                    scriptHeadbob.alturaAtual = transform.position.y;
                scriptHeadbob.velocidade = transform.localScale.y < escalaYPadrao ? 2f : scriptHeadbob.velocidadeComum;
                break;

            case estadoPlayer.correndo:                
                if (transform.localScale.y == escalaYPadrao)
                    scriptHeadbob.alturaAtual = scriptHeadbob.get_alturaInicial();
                scriptHeadbob.velocidade = 0.7f;
                break;

            default:
                if (transform.localScale.y == escalaYPadrao)
                    scriptHeadbob.alturaAtual = scriptHeadbob.get_alturaInicial();
                scriptHeadbob.velocidade = transform.localScale.y < escalaYPadrao ? 2f : scriptHeadbob.velocidadeComum;
                break;
        }
        #endregion*/
       
      if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
             if (vel == velAndando)
            {
                Debug.Log("era p tocar");
                audioAndando.enabled = true;
                audioCorrendo.enabled = false;
                audioCorrendo2.enabled = false;
            }
            if (vel == velCorrendo)
            {
                audioAndando.enabled = false;
                audioCorrendo.enabled = true;
                audioCorrendo2.enabled = true;
            }
        }
        else
        {
            audioAndando.enabled = false;
            audioCorrendo.enabled = false;
            audioCorrendo2.enabled = false;
        }

        /*
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            scriptHeadbob.IniciarHeadbob();
        }
        if(Input.GetAxisRaw("Vertical") == 0 && scriptHeadbob.podeBalancar)
        {
            scriptHeadbob.ConcluirHeadbob();
        }
        */




        if (noChao && velocidade.y < 0f)
        {
            velocidade.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && podeTeclar_Agachar)
        {
            Agachar();
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && podeTeclar_Agachar && PodeLevantar()) 
        {
            Levantar();
        }
    }

    public void Agachar()
    {
        transform.localScale = new Vector3(transform.localScale.x, escalaYAgachado, transform.localScale.z);
    }

    public void Levantar()
    {
        transform.localScale = new Vector3(transform.localScale.x, escalaYPadrao, transform.localScale.z);
    }
    bool PodeLevantar()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.gameObject.transform.position, Vector3.up, out hit, escalaYPadrao, camadaChao))
        {
            return false;
        }
        return true;
    }

    private void Andar()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        move = (transform.right * x + transform.forward * z);

        if (move.magnitude > 1f)
            move.Normalize();

        controller.Move(move * vel * Time.deltaTime);        
    }
    private void Gravidade()
    {
        velocidade.y += gravidade * Time.deltaTime;
        controller.Move(velocidade * Time.deltaTime);
    }

    public void DefinirNovoEstado(estadoPlayer novoEstado)
    {
        switch (novoEstado)
        {
            case estadoPlayer.andando:
                estado = estadoPlayer.andando;
                vel = velAndando;
                correndo = false;
                andando = true;
                agachado = false;
                break;

            case estadoPlayer.agachando:
                estado = estadoPlayer.agachando;
                vel = velAgachado;
                correndo = false;
                andando = false;
                agachado = true;
                break;

            case estadoPlayer.correndo:
                estado = estadoPlayer.correndo;
                vel = velCorrendo;
                correndo = true;
                andando = false;
                agachado = false;
                break;

            default:
                estado = estadoPlayer.andando;
                vel = velAndando;
                correndo = false;
                andando = true;
                agachado = false;
                break;
        }
        if (noChao && Input.GetKey(KeyCode.LeftShift))
        {
            estado = estadoPlayer.correndo;
            vel = velCorrendo;
            correndo = true;
            andando = false;
            agachado = false;
        }
        else if (noChao)
        {
            estado = estadoPlayer.andando;
            vel = velAndando;
            correndo = false;
            andando = true;
            agachado = false;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            estado = estadoPlayer.agachando;
            vel = velAgachado;
            correndo = false;
            andando = false;
            agachado = true;
        }
    }
}
