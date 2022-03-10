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
        // open.Play();
        StartCoroutine(DelayCoroutine());
    }

    IEnumerator DelayCoroutine()
    {
        //yield on a new YieldInstruction that waits for x seconds.
        yield return new WaitForSeconds(7f);

        //After we have waited
        door.SetBool("forward", false);
        StartCoroutine(DelayCoroutine1());
    }

    IEnumerator DelayCoroutine1()
    {
        //yield on a new YieldInstruction that waits for x seconds.
        yield return new WaitForSeconds(0.90f);

        //After we have waited
        // close.Play();
    }
}