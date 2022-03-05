using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecionaItem : MonoBehaviour
{
    public static SelecionaItem Instance;

    public void Awake() {
        Instance = this;
    }

}
