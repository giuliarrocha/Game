using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private GameManager m_Manager;
    public float m_TriggerDistance = 2f;
    void Start()
    {
        GameObject controlCenter = GameObject.Find("ControlCenter");
        if (controlCenter == null) {
            Debug.LogError("Cadê objeto centro de controle?");
        } else {
            m_Manager = controlCenter.GetComponent<GameManager>();
        }
    }
    void OnMouseEnter() {
        if (DistanceFromCamera() <= m_TriggerDistance) {
            m_Manager.CursorTextureChange(true);
        }
    }
    void OnMouseExit () {
        m_Manager.CursorTextureChange(false);
    }
    float DistanceFromCamera() {
        Vector3 heading = transform.position -
        Camera.main.transform.position;
        float distance =
        Vector3.Dot(heading, Camera.main.transform.forward);
        return distance;
    }
}
