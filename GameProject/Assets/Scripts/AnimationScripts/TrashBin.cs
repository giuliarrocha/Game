using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public Animator bin;
    public AudioSource open, close;

    void OnMouseDown()
    {
        bin.SetBool("move", true);
        open.Play();
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3f);
        bin.SetBool("move", false);
        StartCoroutine(DelayCoroutine2());
    }
    IEnumerator DelayCoroutine2()
    {
        yield return new WaitForSeconds(0.20f);
        close.Play();
    }
}
