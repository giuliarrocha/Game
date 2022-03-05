using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Animator car;
    public Animator wheel1, wheel2, wheel3, wheel4;
    public GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        car.SetBool("moving", true);
        wheel1.SetBool("moving", true);
        wheel2.SetBool("moving", true);
        wheel3.SetBool("moving", true);
        wheel4.SetBool("moving", true);
        Destroy(trigger);
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     car.SetBool("moving", false);
    //     wheel1.SetBool("moving", false);
    //     wheel2.SetBool("moving", false);
    //     wheel3.SetBool("moving", false);
    //     wheel4.SetBool("moving", false);
    // }
}
