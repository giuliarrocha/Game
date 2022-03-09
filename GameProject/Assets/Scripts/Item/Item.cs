using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int quant = 0;
    public int quantMax;
    public Sprite icon;
    public ItemType itemType;
    public bool passoIntermediario;
    public bool jogado;
    public bool podeJogar;

    public enum ItemType {
        Bituca,
        CaixaMadeira,
        Canudo,
        Comida,
        GarrafaVidro,
        Latinha,
        Papel,
        Pet,
        Pilha,
        Remedio,
        Papelao
    }
}