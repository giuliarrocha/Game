using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Car : MonoBehaviour
{
    public Animator car;
    public Animator wheel1, wheel2, wheel3, wheel4;
    public int totalItens = 0;
    private GameManager m_Manager;
    public Transform canvas;
    public GameObject mensagemPrefabAcaoEfetuada, mensagemPrefabErro;
    private GameObject instanciaMensagemAcaoEfetuada, instanciaMensagemErro;

    void Start() {
        totalItens = 0;
        GameObject controlCenter = GameObject.Find("ControlCenter");
        m_Manager = controlCenter.GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        bool andar = false;
        bool guardaItemCarro = false;
        string texto = "";
        if(instanciaMensagemErro)
            Destroy(instanciaMensagemErro);
        if(instanciaMensagemAcaoEfetuada)
            Destroy(instanciaMensagemAcaoEfetuada);

        //if (String.Equals(itensAchados.text,"27"))
        if(m_Manager.segurandoObj){
            if (m_Manager.idObj==3 || m_Manager.idObj==4 || m_Manager.idObj==8 || m_Manager.idObj==9){
                //Colocar no carro Caixa de Madeira (3), Bituca (4), Remedio (8), Pilha (9)
                //Carro so anda quando tiver os 4 tipos
                totalItens++;
                guardaItemCarro = true;
                if (totalItens==4)
                    andar = true; 
                
            }
            else {
                texto = "Local incorreto para descarte do lixo.";
                andar = false;
            }
        }
        else {
            texto = "Nao ha nada a ser jogado";
            andar = false; 
        }
        
        if(guardaItemCarro) {
            instanciaMensagemAcaoEfetuada = Instantiate(mensagemPrefabAcaoEfetuada, canvas);
            var textoAcaoEfetuada = instanciaMensagemAcaoEfetuada.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textoAcaoEfetuada.text = "Item Guardado!";
            m_Manager.segurandoObj = false;
            Destroy(m_Manager.prefab);
            m_Manager.atualizaItemStatus(1);
        }
        else {
            instanciaMensagemErro = Instantiate(mensagemPrefabErro, canvas);
            var textoErro = instanciaMensagemErro.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textoErro.text = texto;
        }
        if (andar) {
            car.SetBool("moving", true);
            wheel1.SetBool("moving", true);
            wheel2.SetBool("moving", true);
            wheel3.SetBool("moving", true);
            wheel4.SetBool("moving", true);
        }


    }

    // private void OnTriggerExit(Collider other)
    // {
    //     car.SetBool("moving", false);
    //     wheel1.SetBool("moving", false);
    //     wheel2.SetBool("moving", false);
    //     wheel3.SetBool("moving", false);
    //     wheel4.SetBool("moving", false);
    // }
}
