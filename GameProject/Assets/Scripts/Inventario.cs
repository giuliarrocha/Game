using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public RectTransform content;
    public List<GameObject> itens;

    void addItem()
    {
        if(content.childCount < itens.Count)
        {
            GameObject item = Instantiate(itens[content.childCount], content.position, Quaternion.identity) as GameObject;
            item.transform.parent = content.transform;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        addItem();
    }
}
