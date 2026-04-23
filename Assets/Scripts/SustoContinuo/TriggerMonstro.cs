using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonstro : MonoBehaviour
{
    public GameObject MonstroAtivado;
    [SerializeField] AudioSource AlertaMonstro;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Funcionou");
            MonstroAtivado.SetActive(true);
            AlertaMonstro.enabled = true;
            Invoke("DestruirObjeto", 8f);
        } 
    }
    private void DestruirObjeto()
    {
        Destroy(this.gameObject);
    }
}
