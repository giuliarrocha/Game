using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Texture DefaultCursor;
    private Texture m_CurrentCursor;
    private bool m_Navigating;
    public Texture m_MouseOver;
    // para quando seleciona lixo
    public bool segurandoObj;
    public GameObject prefabLatinha;
    public GameObject prefabBituca;
    public GameObject prefabCaixa;
    public GameObject prefabCanudo;
    public GameObject prefabComida;
    public GameObject prefabGarVidro;
    public GameObject prefabPapel;
    public GameObject prefabPet;
    public GameObject prefabPilha;
    public GameObject prefabRemedio;
    public GameObject prefabPapelao;
    public GameObject prefab;
    public int idObj;
    private Vector3 prefabPosAnterior;
    public InventoryManager inventario;

    void Start()
    {
        m_CurrentCursor = DefaultCursor;
        segurandoObj = false;
        prefabPosAnterior = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (segurandoObj) {
            atualizaPosObj();
        }
        else {
            m_Navigating = Input.GetButton ("Horizontal")
            || Input.GetButton ("Vertical")
            || Input.GetButton ("Turn"); 
        }
        
    }
    
    public void CursorTextureChange(bool change) {
        m_CurrentCursor = change ?
        m_MouseOver : DefaultCursor;
    }
    public void CursorTextureDefault() {
        m_CurrentCursor = DefaultCursor;
    }

    public void CursorTurnIntoObject(bool change, string nomeObjSegurado) {
        segurandoObj = change;
        foreach (var x in inventario.Itens) {
            if (String.Equals(x.itemName, nomeObjSegurado)) {
                if(x.jogado)
                    segurandoObj = false;
            }
        }
        if(segurandoObj)
        {
            
            Vector3 mousePos = Input.mousePosition;
            mousePos.y = Screen.height - mousePos.y - 5.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            switch (nomeObjSegurado) {
                case "Bituca de Cigarro":
                    prefab = Instantiate (prefabBituca, objectPos, Quaternion.identity);
                    idObj = 4;
                    break;
                case "Caixa de Madeira":
                    prefab = Instantiate (prefabCaixa, objectPos, Quaternion.identity);
                    idObj = 3;
                    break;
                case "Canudo Plastico":
                    prefab = Instantiate (prefabCanudo, objectPos, Quaternion.identity);
                    idObj = 11;
                    break;
                case "Restos de Comida":
                    prefab = Instantiate (prefabComida, objectPos, Quaternion.identity);
                    idObj = 5;
                    break;
                case "Garrafa Vidro":
                    prefab = Instantiate (prefabGarVidro, objectPos, Quaternion.identity);
                    idObj = 6;
                    break;
                case "Latinha":
                    prefab = Instantiate (prefabLatinha, objectPos, Quaternion.identity);
                    idObj = 1;
                    break;
                case "Papel":
                    prefab = Instantiate (prefabPapel, objectPos, Quaternion.identity);
                    idObj = 2;
                    break;
                case "Papelao":
                    prefab = Instantiate (prefabPapelao, objectPos, Quaternion.identity);
                    idObj = 10;
                    break;
                case "Garrafa Pet":
                    prefab = Instantiate (prefabPet, objectPos, Quaternion.identity);
                    idObj = 7;
                    break;
                case "Pilha":
                    prefab = Instantiate (prefabPilha, objectPos, Quaternion.identity);
                    idObj = 9;
                    break;
                case "Remedio":
                    prefab = Instantiate (prefabRemedio, objectPos, Quaternion.identity);
                    idObj = 8;
                    break;
            }
        }
    }

    public void atualizaItemStatus(int index) {
        if (index == 1) {
            foreach (var x in inventario.Itens) {
                if (x.id == idObj) {
                    x.jogado = true; //identifica que o objeto foi jogado
                    inventario.update();
                }
            }
        }
        else {
            foreach (var x in inventario.Itens) {
                if (x.id == idObj) {
                    x.passoIntermediario = false; //identifica que o objeto foi jogado
                }
            }
        }
    }

    public void atualizaPosObj() {

        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            // Debug.Log("ray "+raycastHit.point);
            if(Vector3.Distance(Camera.main.transform.position, raycastHit.point) < 1.72)
                prefabPosAnterior = raycastHit.point;
            
            // Debug.Log("camera e hit "+Vector3.Distance(Camera.main.transform.position, raycastHit.point));
            // Debug.Log("prefab e hit "+ Vector3.Distance(prefab.transform.position, raycastHit.point));
            // Debug.Log("prefab e camera "+ Vector3.Distance(prefab.transform.position, Camera.main.transform.position));
        }
        Vector3 objectPos = prefabPosAnterior;
        // objectPos.x -= prefab.transform.GetComponent<Renderer>().bounds.size.x/2f;
        // objectPos.y -= prefab.transform.GetComponent<Renderer>().bounds.size.y/2f;
        objectPos.z -= prefab.transform.GetComponent<Renderer>().bounds.size.z/2f;
        prefab.transform.position = objectPos;
    }
    
    void OnGUI() {
        if (!m_Navigating) {
            Cursor.lockState = CursorLockMode.None;
            var pos = Input.mousePosition;
            GUI.DrawTexture(
                new Rect(pos.x, Screen.height - pos.y, 36f, 36f),
                m_CurrentCursor
            );
        }
    }
}
