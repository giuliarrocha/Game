using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int scene;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
    }
}
