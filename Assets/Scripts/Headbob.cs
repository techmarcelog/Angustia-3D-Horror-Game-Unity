using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    [SerializeField] bool deveSubir;
    [SerializeField] float alturaInicial;
    public bool podeBalancar = false;
    public float velocidade = 0.1f;
    public float velocidadeComum { get; } = 0.5f;
    
    [SerializeField] float medidaMovimento = 0.01f;
    public float alturaAtual;
    Movimentacao.estadoPlayer estadoDoPlayer;

    private void Start()
    {
        
        alturaInicial = transform.position.y;
        alturaAtual = alturaInicial;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, alturaInicial, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if(podeBalancar) balancarCabeca();
        if (!podeBalancar)
        { 
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, alturaAtual, transform.position.z), new Vector3(transform.position.x, alturaAtual, transform.position.z), velocidade * Time.fixedDeltaTime);           
        }
    }

    public float get_alturaInicial()
    {
        return alturaInicial;
    }

    void balancarCabeca()
    {
        if (deveSubir)
        {
         //   Debug.Log("Subiu até o limite " + alturaAtual.ToString() + " e " + transform.position.y.ToString());
            if (transform.position.y == alturaAtual) Debug.Log("Ingual");
            if (transform.position.y >= alturaAtual)
            {
                Debug.Log("YEs it is");
                deveSubir = false;
                
                return;
            }
            subir();
        }
        if (!deveSubir)
        {
            if (transform.position.y <= alturaAtual - medidaMovimento)
            {
                deveSubir = true;
                Debug.Log("Desceu até o limite " + (alturaAtual - medidaMovimento).ToString());
                return;
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                GetComponentInParent<Movimentacao>().Levantar();
                return;
            }
            if (GetComponentInParent<Movimentacao>().estado == Movimentacao.estadoPlayer.correndo)
            {

            }

            descer();
        }

    }

    public void IniciarHeadbob()
    {
        podeBalancar = true;
     //  this.enabled = true;
    }

    public void ConcluirHeadbob()
    {
        deveSubir = true;
        podeBalancar = false;
    }

    public float Atualizar_alturaAtual() //   ELE RETORNA FLOAT PRA CASO O VALOR DA NOVA ALTURA PRECISE SER GUARDADO EM ALGUM OUTRO LUGAR; TIPO O INSTANTIATE
    {
        alturaAtual = transform.position.y;
        return alturaAtual;
    }
    void subir()
    {
    
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, alturaAtual, transform.position.z), velocidade * Time.fixedDeltaTime);
    }

    void descer()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, alturaAtual - medidaMovimento, transform.position.z), velocidade * Time.fixedDeltaTime);
    }

    
}
