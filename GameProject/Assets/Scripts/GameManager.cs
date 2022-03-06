using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture DefaultCursor;
    private Texture m_CurrentCursor;
    private bool m_Navigating;
    public Texture m_MouseOver;
    public bool segurandoObj;
    public GameObject prefabLatinha;
    public GameObject obj;
    void Start()
    {
        m_CurrentCursor = DefaultCursor;
        segurandoObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (segurandoObj) {
            //nao funciona
            Vector3 novaPosicao = Input.mousePosition;
            novaPosicao.z = 2.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(novaPosicao);
            prefabLatinha.transform.position = novaPosicao;
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

    public void CursorTurnIntoObject(bool change) {
        Debug.Log("clico");
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 2.0f;       // we want 2m away from the camera position
        //Instantiate(prefabLatinha, Camera.current.ScreenToWorldPoint(mousePos), Quaternion.identity);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 2.0f;
        mousePos.y += 12.0f;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Instantiate(yourPrefab, objectPos, Quaternion.identity);
        //Vector3 cursorPos = Input.mousePosition;
        Instantiate (prefabLatinha, objectPos, Quaternion.identity);
        segurandoObj = change;
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
