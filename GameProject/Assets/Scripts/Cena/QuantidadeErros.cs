using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantidadeErros : MonoBehaviour
{
    public TextMeshProUGUI erros;
    public Data saveItemData;
    
    void Start()
    {
        erros.text = saveItemData.numErros.ToString();
    }
}
