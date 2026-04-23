using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampoDeVisao : MonoBehaviour
{
    public float raio;
    [Range(0, 360)]
    public float angulo;

    public GameObject referenciaPlayer;

    public LayerMask camadaAlvo;
    public LayerMask camadaObstaculo;
    
    public bool podeVerPlayer;




    private void Start()
    {

        referenciaPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        ChecarCampoDeVisao();
    }

    private void ChecarCampoDeVisao()
    {
        Collider[] raioFOV = Physics.OverlapSphere(transform.position, raio, camadaAlvo);

        if (raioFOV.Length != 0)
        {
            Transform player = raioFOV[0].transform;
            Vector3 direcaoParaPlayer = (player.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, direcaoParaPlayer) < angulo / 2)
            {
                float distanciaParaPlayer = Vector3.Distance(transform.position, player.position);

                if (!Physics.Raycast(transform.position, direcaoParaPlayer, distanciaParaPlayer, camadaObstaculo))
                    podeVerPlayer = true;
                else
                    podeVerPlayer = false;
            }
            else
                podeVerPlayer = false;
        }
        else if (podeVerPlayer)
        {
            podeVerPlayer = false;
        }
        //float distanciaAudicao = Vector3.Distance(transform.position, referenciaPlayer.transform.position);
        //if(referenciaPlayer.GetComponent<Movimentacao>().)
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LuzLanterna"))
        {
            podeVerPlayer = true;
        }
        
    }
}
