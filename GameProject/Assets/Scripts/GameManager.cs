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
    public GameObject prefab;
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

    public void CursorTurnIntoObject(bool change) {
        Vector3 mousePos = Input.mousePosition;
        mousePos.y = Screen.height - mousePos.y - 5.0f;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        prefab = Instantiate (prefabLatinha, objectPos, Quaternion.identity);
        segurandoObj = change;
    }

    public void atualizaPosObj() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
        objectPos.y -= 0.3f;
        objectPos.z += 0.8f;
        prefab.transform.position = objectPos;
        //prefab.transform.rotation.y = Camera.main.transform.rotation.y;
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
