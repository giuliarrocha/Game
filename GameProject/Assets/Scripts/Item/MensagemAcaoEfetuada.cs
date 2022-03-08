using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensagemAcaoEfetuada : MonoBehaviour
{ // Jogado! Lavado!
    public RuntimeAnimatorController controller; 

    // Start is called before the first frame update
    void Start()
    {
        Animator animator = this.GetComponent<Animator>();
        animator.runtimeAnimatorController = controller;
    }
}