using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Animator water;
    
    void OnMouseDown()
    {
        water.SetBool("falling", true);
        //Debug.Log("down");
    }
}
