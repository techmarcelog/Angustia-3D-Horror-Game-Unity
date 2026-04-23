using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }

    public void SairDoJogo()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
    }
}
