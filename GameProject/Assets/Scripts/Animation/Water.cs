using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Animator water;
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
            water.SetBool("falling", true); //Ativando a torneira
        }
    }
}
