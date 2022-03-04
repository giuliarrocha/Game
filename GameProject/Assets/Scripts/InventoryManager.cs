using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Itens = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public TextMeshProUGUI itensAchados;
    public int numItens = 0;

    private void Awake()
    {
        Instance = this;
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
        /*
            if (item.quant == 0) {
            item.quant++;
            Itens.Add(item);
        }
        else {
            foreach (var x in Itens) {
                if (x.id == item.id)
                    x.quant++;
            }
        }*/
        numItens++;
    }

    public void Remove(Item item)
    {
        Itens.Remove(item);
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
        }
    }

    public void Update()
    {
        ListItens();
        itensAchados.text = numItens.ToString();
    }
}
