using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaterAnimationEvent : MonoBehaviour
{
    public ParticleSystem ps;
    public AudioSource clip;
    public Animator water;

    void playParticle ()
    {
        ps.Play();
        clip.Play();
    }

    void stopParticle ()
    {
        ps.Stop();
        water.SetBool("falling", false);
    }
}