using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TrashBin : MonoBehaviour
{
    public Animator bin;
    public int idTrash; //1-Papel (azul), 2-Vidro (verde), 3-Plastico (vermelho), 4-Metal (amarelo), 5-Organico (marrom)
    public AudioSource open, close;
    public GameManager m_Manager;
    public TextMeshProUGUI itensAchados;

    void Start() {
        GameObject controlCenter = GameObject.Find("ControlCenter");
        m_Manager = controlCenter.GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        bool abrir = false;
        bool naoJogar = false;
        foreach (var x in m_Manager.inventario.Itens) {
            if (x.id == m_Manager.idObj) {
                if(x.passoIntermediario)
                    naoJogar = true;
            }
        }
        //if (String.Equals(itensAchados.text,"27"))
        if(m_Manager.segurandoObj){
            if (idTrash==1 && (m_Manager.idObj==2 || m_Manager.idObj==10)){
                abrir = true; 
                //Lixeira para Papeis (Azul)
                //Lixos = Papel (id=2), Papelao (id=10)
            }
            else if(idTrash==2 && m_Manager.idObj==6){
                //Lixeira para Vidro (Verde)
                //Lixos = Garrafa Vidro (id=6)
                if (naoJogar) {
                    abrir = false;
                    Debug.Log("Lixo necessita de tratamento previo");
                }
                else
                    abrir = true;
                
            }
            else if (idTrash==3 && (m_Manager.idObj==7 || m_Manager.idObj==11)){ 
                //Lixeira para Plastico (Vermelho)
                //Lixos = Pet (id=7), Canudo (id=11)
                if (m_Manager.idObj==7 && naoJogar) {
                    abrir = false;
                    Debug.Log("Lixo necessita de tratamento previo");
                }
                else
                    abrir = true;
                
            }
            else if (idTrash==4 && m_Manager.idObj==1){
                //Lixeira para Metal (Amarelo)
                //Lixos = Latinha (id=1)
                if (naoJogar) {
                    abrir = false;
                    Debug.Log("Lixo necessita de tratamento previo");
                }
                else
                    abrir = true;
                
            }
            else if (idTrash==5 && m_Manager.idObj==5){ 
                abrir = true; 
                //Lixeira para Organico (marrom)
                //Lixos = Comida (id=5)
                
            }
            else {
                Debug.Log("Local incorreto para o descarte do lixo");
                abrir = false; 
            }
        }
        else {
            Debug.Log("Não ha nada a ser jogado");
            abrir = false; 
        }
        
        if(abrir) {
            Debug.Log("Jogado!");
            m_Manager.segurandoObj = false;
            Destroy(m_Manager.prefab);
            m_Manager.atualizaItemStatus(1);
            bin.SetBool("move", true);
            open.Play();
            StartCoroutine(DelayCoroutine());

            //tratar lixo
        }


    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        bin.SetBool("move", false);
        StartCoroutine(DelayCoroutine2());
    }
    IEnumerator DelayCoroutine2()
    {
        yield return new WaitForSeconds(0.20f);
        close.Play();
    }
}
