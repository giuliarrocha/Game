using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MensagemColeta", menuName = "Item/Create New MensagemColeta")]
public class MensagemColeta : ScriptableObject
{
    public string nomeItem;
    public Sprite iconItem;
    public int numColetado = 0;
    public int numMax;
}
