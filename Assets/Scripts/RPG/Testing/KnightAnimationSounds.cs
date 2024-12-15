using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimationSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip swordSwing;


    public void SwingSwordSound()
    {
        audio.clip = swordSwing;
        audio.Play();
    }
}
