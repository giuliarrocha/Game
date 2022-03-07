using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    public Data saveItemData;

    void Start()
    {
        saveItemData = Resources.Load<Data>("ItemDataSceneSwitch");

        item.posicao = transform.localPosition;

        List<Vector3> Itens = Data.casa ? saveItemData.ItensCasa : saveItemData.ItensPraia;

        foreach (Vector3 Item in Itens)
        {
            if(Mathf.Ceil(item.posicao.x) == Mathf.Ceil(Item.x) && Mathf.Ceil(item.posicao.y) == Mathf.Ceil(Item.y))
                Destroy(gameObject);
        //Debug.Log( "spawn" + item.posicao.ToString("F4") + "spawn" + Item.ToString("F4"));
        }
    }
}
