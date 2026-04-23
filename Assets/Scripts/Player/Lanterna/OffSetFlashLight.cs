using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSetFlashLight : MonoBehaviour
{

    GameObject goFollow;
    [SerializeField] private float speed = 3f;
    private Vector3 offSet;

    void Start()
    {
        goFollow = GameObject.FindGameObjectWithTag("MainCamera");
        offSet = transform.position - goFollow.transform.position;
    }

    void Update()
    {
        transform.position = goFollow.transform.position + offSet;
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
    }
}
