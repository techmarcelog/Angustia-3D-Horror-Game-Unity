using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustoPercepcao : MonoBehaviour
{
    [SerializeField] GameObject MonstroPercepcao;
    [SerializeField] GameObject SustoVolta;
    public float tempoDMonstro;
    public float tempoDCollider;
    public bool gatilhaVolta;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MonstroPercepcao.SetActive(true);
            Invoke("DestruirMonstro", tempoDMonstro);
            Invoke("DestruirCollider", tempoDCollider);
            if (gatilhaVolta && SustoVolta != null)
            {
                SustoVolta.SetActive(true);
            }
        }
    }
    public void DestruirMonstro() 
    {
        Destroy(MonstroPercepcao);
    }
    public void DestruirCollider()
    {
        Destroy(this.gameObject);
    }
}
