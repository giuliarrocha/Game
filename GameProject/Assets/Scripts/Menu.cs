using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Data saveItemData;
    public void LoadScene (int indexScene) {
        saveItemData.Itens = null;
        saveItemData.numItens = -1;
        saveItemData.InventoryItens = null;

        SceneManager.LoadScene(indexScene);
    }
    public void ExitGame () {
        Application.Quit();
    }
}
