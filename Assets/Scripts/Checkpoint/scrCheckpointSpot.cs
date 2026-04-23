using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCheckpointSpot : MonoBehaviour
{
    [SerializeField] scrCheckpointManager scriptCheckpointManager;

    void Start()
    {
        scriptCheckpointManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<scrCheckpointManager>();
    }

    void OnTriggerEnter(Collider colisao)
    {
        scriptCheckpointManager.SetCheckpoint(this.gameObject.transform.position);
    }
}
