using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinAnimation : MonoBehaviour
{
    public AudioSource open, close;

    private void openFunction()
    {
        open.Play();
    }
    
    private void closeFunction()
    {
        close.Play();
    }
}
