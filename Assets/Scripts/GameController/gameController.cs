using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public bool pausado;
    void Start()
    {
    }

    void Update()
    {
    }

    public void PausarJogo()
    {
        Time.timeScale = 0f;
        pausado = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DespausarJogo()
    {
        Time.timeScale = 1.0f;
        pausado = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
