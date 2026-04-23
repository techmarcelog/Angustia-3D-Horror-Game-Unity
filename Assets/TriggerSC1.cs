using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSC1 : MonoBehaviour
{
    [SerializeField] private SC_Controller scr_controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            scr_controller.DiminuirCorredor();
        }
    }
}
