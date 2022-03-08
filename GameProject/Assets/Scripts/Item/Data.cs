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
    public static bool casa = false;
    public List<Vector3> ItensCasa = new List<Vector3>();
    public List<Vector3> ItensPraia = new List<Vector3>();


    
    /*
    public int numItens
    {
        get { return numItens; }
        set { numItens = value; }
    }
    
    // private List<Item> Itens = new List<Item>();
    // private int numItens = -1;
    // private InventoryItemController[] InventoryItens;
    public static bool casa = false;
    // private List<Vector3> ItensCasa = new List<Vector3>();
    // private List<Vector3> ItensPraia = new List<Vector3>();

    
    public List<Item> Itens
    {
        get { return Itens; }
        set { Itens = value; }
    }

    public int numItens
    {
        get { return numItens; }
        set { numItens = value; }
    }

    public InventoryItemController[] InventoryItens
    {
        get { return InventoryItens; }
        set { InventoryItens = value; }
    }

    public List<Vector3> ItensCasa
    {
        get { return ItensCasa; }
        set { ItensCasa = value; }
    }

    public List<Vector3> ItensPraia
    {
        get { return ItensPraia; }
        set { ItensPraia = value; }
    }
    */
}