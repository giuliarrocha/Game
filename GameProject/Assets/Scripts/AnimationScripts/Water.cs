using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Animator water;
    
    private void OnTriggerEnter(Collider other)
    {
        water.SetBool("falling", true);
        //Debug.Log("down");
    }
}
