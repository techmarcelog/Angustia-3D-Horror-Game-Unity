using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seringa : MonoBehaviour
{
    PlayerController player;
    int vida = 25;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        
    }

    public void Usar()
    {
        player.GanharVida(vida);
    }
}
