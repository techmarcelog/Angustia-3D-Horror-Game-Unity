using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerSpawner : MonoBehaviour
{
    [SerializeField] scrCheckpointManager scriptCheckpointManager;
    [SerializeField] GameObject playerPrefab;

    private void Awake()
    {
        scriptCheckpointManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<scrCheckpointManager>();

        if (!scriptCheckpointManager.checkpointJaFoiUsado())
        {
            Vector3 checkpointDePosicaoInicial = GameObject.FindGameObjectWithTag("cp_nascimento").transform.position;
            playerPrefab.transform.position = checkpointDePosicaoInicial;        
        }
        else
        {
            playerPrefab.transform.position = scriptCheckpointManager.GetCheckpoint();
            scriptCheckpointManager.desativarItensDoCenarioJaPegos();
        }

        Instantiate(playerPrefab);
    }

    private void Start()
    {
        if (!scriptCheckpointManager.checkpointJaFoiUsado())
        {
            scriptCheckpointManager.atribuirValorInicial_ValoresItensNaCenaExistentes();
        }
    }
}
