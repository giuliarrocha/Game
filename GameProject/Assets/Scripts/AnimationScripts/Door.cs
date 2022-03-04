using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZDoor;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Animator door;
    public AudioSource open, close;

    private void OnTriggerEnter(Collider other)
    {
        door.SetBool("forward", true);
        open.Play();
    }
    
    private void OnTriggerExit(Collider other)
    {
        door.SetBool("forward", false);
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        //yield on a new YieldInstruction that waits for x seconds.
        yield return new WaitForSeconds(0.90f);

        //After we have waited
        close.Play();
    }
}