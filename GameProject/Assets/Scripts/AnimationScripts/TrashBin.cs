using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public Animator bin;
    public AudioSource open, close;

    private void OnTriggerEnter(Collider other)
    {
        bin.SetBool("move", true);
        open.Play();
    }
    
    private void OnTriggerExit(Collider other)
    {
        bin.SetBool("move", false);
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        //yield on a new YieldInstruction that waits for x seconds.
        yield return new WaitForSeconds(0.90f);

        //After we have waited
        //
        close.Play();
    }
}
