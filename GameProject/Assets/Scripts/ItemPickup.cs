using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    private GameManager m_Manager;

    void Pickup()
    {
        // para cursor voltar ao estado default depois do click
        GameObject controlCenter = GameObject.Find("ControlCenter");
        if (controlCenter == null) {
            Debug.LogError("Cadê objeto centro de controle?");
        } else {
            m_Manager = controlCenter.GetComponent<GameManager>();
        }
        m_Manager.CursorTextureDefault();

        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
