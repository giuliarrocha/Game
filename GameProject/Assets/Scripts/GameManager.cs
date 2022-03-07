using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture DefaultCursor;
    private Texture m_CurrentCursor;
    private bool m_Navigating;
    public Texture m_MouseOver;
    // para quando seleciona lixo
    public bool segurandoObj;
    public GameObject prefabLatinha;
    public GameObject prefab;
    private Vector3 prefabPosAnterior;

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

    public void CursorTurnIntoObject(bool change) {
        segurandoObj = change;
        if(segurandoObj)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.y = Screen.height - mousePos.y - 5.0f;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            prefab = Instantiate (prefabLatinha, objectPos, Quaternion.identity);
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
