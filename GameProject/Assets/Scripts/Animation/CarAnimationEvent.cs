using System.Collections;
using UnityEngine;

public class CarAnimationEvent : MonoBehaviour
{
    public GameObject car;
    public GameObject wheel1, wheel2, wheel3, wheel4;
    public GameObject rightLamp1,rightLamp2;
    public GameObject leftLamp1,leftLamp2;
    public GameObject rightTailLamp1,rightTailLamp2;
    public GameObject leftTailLamp1,leftTailLamp2;
    public AudioSource mp3;

    // the function to be called as an event
    public void horn()
    {
        mp3.Play();
    }
    
    // the function to be called as an event
    public void changeRender(Material fadeMat)
    {
        car.GetComponent<Renderer>().material = fadeMat;

    }
    
    // the function to be called as an event
    public void canFade()
    {
        fade(rightLamp1);
        fade(rightLamp2);
        fade(leftLamp1);
        fade(leftLamp2);

        fade(rightTailLamp1);
        fade(rightTailLamp2);
        fade(leftTailLamp1);
        fade(leftTailLamp2);

        fade(wheel1);
        fade(wheel2);
        fade(wheel3);
        fade(wheel4);

        fade(car);
    }

    public void fade(GameObject obj)
    {
        MeshRenderer myMeshRender = obj.GetComponent<MeshRenderer>();

        float myLerpDuration = 2f; // seconds
        Color myEndColor = new Color(myMeshRender.material.color.r, myMeshRender.material.color.g, myMeshRender.material.color.b, 0f);

        StartCoroutine(Lerp_MeshRenderer_Color(obj, myMeshRender, myLerpDuration, myMeshRender.material.color, myEndColor));
    }
    private IEnumerator Lerp_MeshRenderer_Color(GameObject obj, MeshRenderer target_MeshRender, float lerpDuration, Color startLerp, Color targetLerp)
    {
        float lerpStart_Time = Time.time;
        float lerpProgress;
        bool lerping = true;
        while (lerping)
        {
            yield return new WaitForEndOfFrame();
            lerpProgress = Time.time - lerpStart_Time;
            if (target_MeshRender != null)
            {
                target_MeshRender.material.color = Color.Lerp(startLerp, targetLerp, lerpProgress / lerpDuration);
            }
            else
            {
                lerping = false;
            }
            
            
            if (lerpProgress >= lerpDuration)
            {
                lerping = false;
            }
        }
        
        Destroy (obj);
        yield break;
    }

}
