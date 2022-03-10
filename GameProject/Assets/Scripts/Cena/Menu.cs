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
        saveItemData.numErros = 0;
        saveItemData.InventoryItens = null;
        saveItemData.ItensCasa = null;
        saveItemData.ItensPraia = new List<Vector3>();
        saveItemData.numJogados = 0;
        SceneManager.LoadScene(indexScene);
    }
    public void ExitGame () {
        Application.Quit();
    }
}
