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
        // A visibilidade do cursor na tela vai ser habilitada se,
        // e somente se, o usuário não ativar nenhum dos eixos de
        // movimento (i.e. ficar parado)
        Cursor.visible = !Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && !Input.GetButton("Turn"); 
        //Se não tiver Turn nos Inputs,
        //usar no lugar de !Input.GetButton("Turn") o seguinte:
        //!Input.GetButton(“Mouse x”)&&
        //!Input.GetButton(“Mouse y”);
    }
}
