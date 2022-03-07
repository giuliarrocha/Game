﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Itens = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public TextMeshProUGUI itensAchados;
    public int numItens = 0;

    public InventoryItemController[] InventoryItens;

    public GameObject InfoDetails; // tela de fundo do pop-up
    private TextMeshProUGUI Details; // referencia ao campo de texto do pop-up

    public Animator Info;
    public AudioSource open, close;

    public Data saveItemData;
    public GameObject mensagemPrefab;
    public Transform canvas;
    private GameObject instanciaMensagem;

    private void Awake()
    {
        Instance = this;

        Details = InfoDetails.transform.Find("Details").GetComponent<TextMeshProUGUI>();
        InfoDetails.SetActive(false);

        if(saveItemData.numItens != -1)
        {
            // Debug.Log(saveItemData.numItens);
            this.Itens = saveItemData.Itens;
            this.numItens = saveItemData.numItens;
            this.InventoryItens = saveItemData.InventoryItens;
        }
        update();
    }

    private void saveContent()
    {
        saveItemData.Itens = this.Itens;
        saveItemData.numItens = this.numItens;
        saveItemData.InventoryItens = this.InventoryItens;
    }

    public void Add(Item item)
    {   
        bool achou = false;
        foreach (var x in Itens) {
            if (x.id == item.id) {
                x.quant++;
                achou = true;
            }
        }
        if (!achou) {
            item.quant = 1;
            Itens.Add(item);
        }
        numItens++;
        update();
        
        // pop-up MensagemColeta
        instanciaMensagem = Instantiate(mensagemPrefab, canvas); // cria uma mensagemcoleta
        MostraMensagem(item);
    }

    public void MostraMensagem(Item item)
    {
        var nomeItem = instanciaMensagem.transform.Find("NomeItem").GetComponent<TextMeshProUGUI>();
        var itemIcon = instanciaMensagem.transform.Find("IconItem").GetComponent<UnityEngine.UI.Image>();
        var numColetado = instanciaMensagem.transform.Find("NumColetado").GetComponent<TextMeshProUGUI>();
        var numMax = instanciaMensagem.transform.Find("NumMax").GetComponent<TextMeshProUGUI>();

        nomeItem.text = item.itemName;
        itemIcon.sprite = item.icon;
        numColetado.text = item.quant.ToString();
        numMax.text = item.quantMax.ToString();
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(1.6f);
        Destroy(instanciaMensagem);
    }

    public void Remove(Item item)
    {
        Itens.Remove(item);        
        update();
    }

    public void ListItens()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Itens)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>();
            var itemQtd = obj.transform.Find("ItemQtd").GetComponent<UnityEngine.UI.Text>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemQtd.text = item.quant.ToString() + " / " + item.quantMax.ToString();

            ButtonClick btn = obj.AddComponent<ButtonClick>();
            btn.config(InfoDetails, Details, itemName.text, Info, open, close);
        }

        SetInventoryItens();
    }

    // nao fica atualizando toda hora, so na insercao, remocao e no comeco, senao botoes dos itens nao funcionam
    public void update()
    {
        ListItens();
        itensAchados.text = numItens.ToString();
        saveContent();
    }

    public void SetInventoryItens() {
        InventoryItens = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i=0; i<Itens.Count; i++) {
            InventoryItens[i].AddItem(Itens[i]);
        }
    }
}