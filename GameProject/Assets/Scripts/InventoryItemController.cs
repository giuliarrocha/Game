using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem() { // comentei pq da erro
        // switch (item.itemType){
        //     case Item.ItemType.Bituca:
        //         Debug.Log("Bituca");
        //         break;
        //     case Item.ItemType.CaixaMadeira:
        //         Debug.Log("Caixa");
        //         break;
        //     case Item.ItemType.Canudo:
        //         Debug.Log("Canudo");
        //         break;
        //     case Item.ItemType.Comida:
        //         Debug.Log("Comida");
        //         break;
        //     case Item.ItemType.GarrafaVidro:
        //         Debug.Log("Garrafa Vidro");
        //         break;
        //     case Item.ItemType.Latinha:
        //         Debug.Log("Latinha");
        //         break;
        //     case Item.ItemType.Papel:
        //         Debug.Log("Papel");
        //         break;
        //     case Item.ItemType.Pet:
        //         Debug.Log("Garrafa Pet");
        //         break;
        //     case Item.ItemType.Pilha:
        //         Debug.Log("Pilha");
        //         break;
        //     case Item.ItemType.Remedio:
        //         Debug.Log("Remedio");
        //         break;
        //     case Item.ItemType.Sacola:
        //         Debug.Log("Sacola");
        //         break;
        // }
    }

}
