using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int quant = 0;
    public int quantMax;
    public Sprite icon;
    public ItemType itemType;
    public bool passoIntermediario;
    public bool jogado;

    public enum ItemType {
        Bituca,
        CaixaMadeira,
        Canudo,
        Comida,
        GarrafaVidro,
        Latinha,
        Papel,
        Pet,
        Pilha,
        Remedio,
        Papelao
    }
}
/*public Animator water;
    public GameManager m_Manager;

    void Start() {
        GameObject controlCenter = GameObject.Find("ControlCenter");
        m_Manager = controlCenter.GetComponent<GameManager>();
    }
    
    void OnMouseDown()
    {
        bool abrir = false;
        //if (String.Equals(itensAchados.text,"27"))
        if(m_Manager.segurandoObj){
            if (m_Manager.idObj==1 || m_Manager.idObj==6 || m_Manager.idObj==7){
                //Se for latinha (1), garrafa de vidro (6) ou pet (7), pode lavar
                abrir = true; 
            }
            else {
                Debug.Log("Este lixo nao precisa ser lavado");
                abrir = false; 
            }
        }
        else {
            Debug.Log("Nao ha nada a ser lavado");
            abrir = false; 
        }
        
        if(abrir) {
            Debug.Log("Lavado!");
            m_Manager.atualizaItemStatus(2);
            water.SetBool("falling", true);

            //tratar lixo
        }
    }*/