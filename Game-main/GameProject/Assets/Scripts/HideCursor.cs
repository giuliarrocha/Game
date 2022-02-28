using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        
    }

    void LateUpdate()
    {
        Cursor.visible = !Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && !Input.GetButton("Turn"); 
    }
}
