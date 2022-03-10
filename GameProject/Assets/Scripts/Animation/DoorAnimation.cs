using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public AudioSource open, close;
    void openf()
    {
        open.Play();
    }
    void closef()
    {
        close.Play();
    }
}
