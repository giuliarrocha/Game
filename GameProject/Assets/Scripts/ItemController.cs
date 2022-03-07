using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;

    void Start()
    {
        // para nao mostrar mais lixo ja pego quando muda de cena e volta
        Vector3 posicao = transform.localPosition; // pega posicao do item com esse script
        Data saveItemData = Resources.Load<Data>("ItemDataSceneSwitch");

        List<Vector3> Itens = Data.casa ? saveItemData.ItensCasa : saveItemData.ItensPraia;

        foreach (Vector3 Item in Itens)
        {
            if(Vector3.Distance(posicao, Item) <= 0.0003)
                Destroy(gameObject);
            //Debug.Log( gameObject.name + posicao.ToString("F4") + "spawn" + Item.ToString("F4") + "\n: " + Vector3.Distance(posicao, Item));
        }
    }

    // public bool Approximately(Vector3 me, Vector3 other, float allowedDifference)
    // {
    //     var dx = me.x - other.x;
    //     if (Mathf.Abs(dx) > allowedDifference)
    //         return false;

    //     var dy = me.y - other.y;
    //     if (Mathf.Abs(dy) > allowedDifference)
    //         return false;

    //     var dz = me.z - other.z;

    //     return Mathf.Abs(dz) >= allowedDifference;
    // }
}
