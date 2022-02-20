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
        Vector3 position = Input.mousePosition;
        transform.position = new Vector3(position.x + 12f, position.y - 12f);
    }
}
