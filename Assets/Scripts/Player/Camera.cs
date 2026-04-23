using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    public Transform corpoPlayer;

    bool estaRotacionando = false;
    float alvoRotacao = 0.0f;
    float rotacaoX = 0f;
    float velocidadeRotacao = 400f;
    public Slider slider;
    public float sensibilidadeCursor = 100f;

    private void Awake()
    {
        sensibilidadeCursor = PlayerPrefs.GetFloat("SensibilidadeAtual", 100);
        slider.value = sensibilidadeCursor / 10;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
 
        PlayerPrefs.SetFloat("SensibilidadeAtual", sensibilidadeCursor);
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeCursor * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeCursor * Time.deltaTime;

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90, 90);
        
        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        corpoPlayer.Rotate(Vector3.up * mouseX);

       /* if (estaRotacionando)
        {
            float flip = velocidadeRotacao * Time.deltaTime;
            corpoPlayer.Rotate(Vector3.up, flip);

            if (Mathf.Abs(corpoPlayer.eulerAngles.y - alvoRotacao) < 1.0f)
            {
                estaRotacionando = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            estaRotacionando = true;
            alvoRotacao = (corpoPlayer.eulerAngles.y + 30.0f) % 180.0f;
        }*/
    }
    public void AjustarVelocidade(float novaVelocidade)
    {
        sensibilidadeCursor = novaVelocidade * 10;
    }
    public void AtivarCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void DesativarCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
