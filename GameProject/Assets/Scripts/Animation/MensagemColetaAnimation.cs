using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagemColetaAnimation : MonoBehaviour
{
    public AudioSource open, close;
    public RuntimeAnimatorController controller; 

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = this.GetComponent<Animator>();
        animator.runtimeAnimatorController = controller;
        open.Play();
    }
}
