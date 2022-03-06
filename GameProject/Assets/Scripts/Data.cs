using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// armazena dados entre as cenas
[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData", order = 1)]
public class Data : ScriptableObject
{
    public List<Item> Itens = new List<Item>();
    public int numItens = -1;
    public InventoryItemController[] InventoryItens;
}