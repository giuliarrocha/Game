using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        // Obtém a posição atual do cursor, variável do tipo Vector3
        Vector3 position = Input.mousePosition;
        // Ajusta posições x e y no objeto 3D, ignorando o z.
        transform.position = new Vector3(
        position.x + 12f, position.y - 12f
        );
    }
}
