using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitch : MonoBehaviour
{
    public int scene;
    private bool entra = false;
    public Transform canvas;
    public GameObject mensagemPrefabAcaoEfetuada;
    private GameObject instanciaMensagemAcaoEfetuada;

    void Update()
    {
        if(Vector3.Distance(Camera.main.transform.position, transform.position) < 3)
        {
            if (Input.GetKey("e"))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(instanciaMensagemAcaoEfetuada)
            Destroy(instanciaMensagemAcaoEfetuada);
        instanciaMensagemAcaoEfetuada = Instantiate(mensagemPrefabAcaoEfetuada, canvas);
        var textoAcaoEfetuada = instanciaMensagemAcaoEfetuada.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        textoAcaoEfetuada.text = "Pressione 'E' para usar a porta!";
    }
    void OnTriggerExit(Collider other)
    {
        if(instanciaMensagemAcaoEfetuada)
            Destroy(instanciaMensagemAcaoEfetuada);
    }
}
