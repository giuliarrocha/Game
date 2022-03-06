
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class InventoryManagerScene2 : MonoBehaviour
{
    public static InventoryManagerScene2 Instance;
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

    private void Awake()
    {
        Instance = this;

        Details = InfoDetails.transform.Find("Details").GetComponent<TextMeshProUGUI>();
        InfoDetails.SetActive(false);

        DontDestroyOnLoad(this.gameObject);

        update();
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
    }

    public void SetInventoryItens() {
        InventoryItens = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i=0; i<Itens.Count; i++) {
            InventoryItens[i].AddItem(Itens[i]);
        }
    }
}


