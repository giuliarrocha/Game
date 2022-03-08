using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Animator car;
    public Animator wheel1, wheel2, wheel3, wheel4;
    public int totalItens = 0;
    public GameManager m_Manager;

    void Start() {
        totalItens = 0;
        GameObject controlCenter = GameObject.Find("ControlCenter");
        m_Manager = controlCenter.GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        bool andar = false;
        bool guardaItemCarro = false;

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
                Debug.Log("Local incorreto para descarte do lixo.");
                andar = false; 
            }
        }
        else {
            Debug.Log("Nao ha nada a ser jogado");
            andar = false; 
        }
        
        if(guardaItemCarro) {
            Debug.Log("Item Guardado!");
            m_Manager.segurandoObj = false;
            Destroy(m_Manager.prefab);
            m_Manager.atualizaItemStatus(1);
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
