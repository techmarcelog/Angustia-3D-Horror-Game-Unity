using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemInterativo
{
    public class Item : MonoBehaviour
    {
        [SerializeField] public string nome;
        [TextArea]
        [SerializeField] public string descricao;

        [SerializeField] public string tamanho;

        [SerializeField] public tipoItem qualItem;

        [SerializeField] public Sprite spriteInventario;

        [SerializeField] public  GameObject objPlayer;

        [SerializeField] public GameObject modelo3dJogo;

        public virtual void Start()
        {
            objPlayer = GameObject.FindGameObjectWithTag("Player");
        }

        public enum tipoItem
        {
            lanterna, remedio, seringa, bateria, itemT1, itemT2, itemT3, peDeCabra, Chave
        }

        public bool ehUmItemGrande()
        {
            if (tamanho == "Grande") return true;
            else return false;
        }

        public void foiPego()
        {
            this.gameObject.SetActive(false);
        }

        public virtual void Usar()
        {

        }
    }
}