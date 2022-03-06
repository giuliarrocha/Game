using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture DefaultCursor;
    private Texture m_CurrentCursor;
    private bool m_Navigating;
    public Texture m_MouseOver;
    void Start()
    {
        m_CurrentCursor = DefaultCursor;
    }

    // Update is called once per frame
    void Update()
    {
        m_Navigating = Input.GetButton ("Horizontal")
        || Input.GetButton ("Vertical")
        || Input.GetButton ("Turn");  
    }
    
    public void CursorTextureChange(bool change) {
        m_CurrentCursor = change ?
        m_MouseOver : DefaultCursor;
    }
    public void CursorTextureDefault() {
        m_CurrentCursor = DefaultCursor;
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
