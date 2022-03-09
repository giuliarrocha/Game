﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Water : MonoBehaviour
{
    public Animator water;
    private GameManager m_Manager;
    public Transform canvas;
    public GameObject mensagemPrefabAcaoEfetuada, mensagemPrefabErro;
    private GameObject instanciaMensagemAcaoEfetuada, instanciaMensagemErro;
    public TextMeshProUGUI itensAchados;
    public Data saveItemData;
    public TextMeshProUGUI numErros;

    void Start() {
        GameObject controlCenter = GameObject.Find("ControlCenter");
        m_Manager = controlCenter.GetComponent<GameManager>();
    }
    
    void OnMouseDown()
    {
        bool abrir = false;
        string texto = "";
        if(instanciaMensagemErro)
            Destroy(instanciaMensagemErro);
        if(instanciaMensagemAcaoEfetuada)
            Destroy(instanciaMensagemAcaoEfetuada);
        
        if (String.Equals(itensAchados.text,"27")) {
            if(m_Manager.segurandoObj){
                if (m_Manager.idObj==1 || m_Manager.idObj==6 || m_Manager.idObj==7){
                    //Se for latinha (1), garrafa de vidro (6) ou pet (7), pode lavar
                    abrir = true;
                }
                else {
                    texto = "Este lixo nao precisa ser lavado!";
                    abrir = false;
                    numErros.text = (++saveItemData.numErros).ToString();
                }
            }
            else {
                texto = "Não há nada a ser lavado!";
                abrir = false;
                numErros.text = (++saveItemData.numErros).ToString();
            }
        }
        else {
            texto = "Todos os lixos precisam ser coletados primeiro!";
            abrir = false;
            numErros.text = (++saveItemData.numErros).ToString();
        }
        if(abrir) {
            instanciaMensagemAcaoEfetuada = Instantiate(mensagemPrefabAcaoEfetuada, canvas);
            var textoAcaoEfetuada = instanciaMensagemAcaoEfetuada.transform.Find("Text").GetComponent<TextMeshProUGUI>();
            textoAcaoEfetuada.text = "Lavado!";
            m_Manager.atualizaItemStatus(2);
            water.SetBool("falling", true); //Ativando a torneira
            return;
        }
        
        instanciaMensagemErro = Instantiate(mensagemPrefabErro, canvas);
        var textoErro = instanciaMensagemErro.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        textoErro.text = texto;
    }
}
