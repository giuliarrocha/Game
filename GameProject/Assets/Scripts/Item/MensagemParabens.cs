using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MensagemParabens", menuName = "Item/Create New MensagemParabens")]
public class MensagemParabens : ScriptableObject
{
    public string nomeItem;
    public Sprite iconItem;
    public int numColetado = 0;
    public int numMax;
}
