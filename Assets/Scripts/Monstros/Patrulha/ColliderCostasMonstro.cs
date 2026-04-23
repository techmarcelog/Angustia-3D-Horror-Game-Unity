using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCostasMonstro : MonoBehaviour
{
    [SerializeField] GameObject monstroPatrulha;
    public bool podeVerPlayerCostas = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podeVerPlayerCostas = true;
            monstroPatrulha.GetComponent<ControladorPatrulha>().Perseguir();
        }
    }
   private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podeVerPlayerCostas = false;
        }
    }
}
