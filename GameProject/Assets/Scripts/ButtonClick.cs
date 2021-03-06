using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems; // Required when using Event data.

public class ButtonClick : EventTrigger
{
    public GameObject InfoDetails; // tela de fundo do pop-up
    public TextMeshProUGUI Details;
    public TextMeshProUGUI Explicacao; // referencia ao campo de texto para imprimir a descricao
    public string CustomDetails, explicacao; // texto da descricao
    public string nomeObjSegurado; //nome do objeto selecionado no inventario
    public Animator Info;
    public AudioSource open, close;
    public GameManager m_Manager;

    public void config(GameObject InfoDetails, TextMeshProUGUI Details, TextMeshProUGUI Explicacao, string CustomDetails, string explicacao, Animator Info, AudioSource open, AudioSource close)
    {
        this.InfoDetails = InfoDetails;
        this.Details = Details;
        this.Explicacao = Explicacao;
        this.CustomDetails = CustomDetails;
        this.explicacao = explicacao;
        this.Info = Info;
        this.open = open;
        this.close = close;
        this.nomeObjSegurado = CustomDetails;
        
        GameObject controlCenter = GameObject.Find("ControlCenter");
        m_Manager = controlCenter.GetComponent<GameManager>();
    }

    public override void OnInitializePotentialDrag(PointerEventData data)
    {
        if(Input.GetMouseButtonDown(0)) {
            //Debug.Log("Pressed left click.");
            m_Manager.CursorTurnIntoObject(!m_Manager.segurandoObj, nomeObjSegurado);
            if(!m_Manager.segurandoObj)
                Destroy(m_Manager.prefab);
        }
        if(Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Pressed right click.");
            if(!Details.text.Equals(CustomDetails)) {
                Details.text = CustomDetails;
                Explicacao.text = explicacao;
                if(InfoDetails.activeSelf == true) return;
            }

            if(InfoDetails.activeSelf == true) 
            {
                Info.SetBool("change", false);
                close.Play();
                StartCoroutine(DelayCoroutine());
            }
            else
            {
                InfoDetails.SetActive(true);
                Info.SetBool("change", true);
                open.Play();
            }
            
        }

        //if(Input.GetMouseButtonDown(2)) Debug.Log("Pressed middle click.");
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(0.50f);
        InfoDetails.SetActive(!InfoDetails.activeSelf);
    }



    // public override void OnPointerEnter(PointerEventData data)
    // {
    //     Debug.Log("OnPointerEnter called.");
    // }

    // public override void OnPointerExit(PointerEventData data)
    // {
    //     Debug.Log("OnPointerExit called.");
    // }
    
}
