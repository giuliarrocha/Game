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

        // add aos itens coletados
        InventoryManager.Instance.Add(item);

        
        // salva posicao dos itens ja clicados para nao mostrar mais quando mudar de cena e voltar
        Data saveItemData = Resources.Load<Data>("ItemDataSceneSwitch");
        // pega posicao do item com esse script
        Vector3 posicao = transform.localPosition;

        if(Data.casa)
            saveItemData.ItensCasa.Add(posicao);
        else 
            saveItemData.ItensPraia.Add(posicao);

        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
