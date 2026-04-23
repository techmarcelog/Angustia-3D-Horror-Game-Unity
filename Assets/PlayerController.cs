using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject PainelMorreu;
    DetecInteracao scriptDetecInteracao;
    [SerializeField] public bool tentouPegar;
    public int vida;
    gameController scriptGameController;
    void Awake()
    {
        scriptDetecInteracao = this.GetComponentInChildren<DetecInteracao>();       
    }

    void Start()
    {
        vida = 75;
    }

    private void Update()
    {
        if (vida <= 0)
        {
            Morreu();
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Morreu();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void GanharVida(int vidaGanha)
    {
        vida += vidaGanha;
        if(vida>= 100)
        {
            vida = 100;
        }
        
    }

    public void RemoverVida(int vidaPerca)
    {
        vida -= vidaPerca;
    }
    public void Morreu()
    {
        PainelMorreu.SetActive(true);
        //scriptGameController.PausarJogo();
        Cursor.lockState = CursorLockMode.Confined;
    }

}
