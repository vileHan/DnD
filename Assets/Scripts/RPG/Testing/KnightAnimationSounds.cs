using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimationSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip swordSwing;
    public AudioClip heal;
    public AudioClip cast;
    public AudioClip buff;


    public void SwingSwordSound()
    {
        audio.volume = 1f;
        audio.clip = swordSwing;
        audio.Play();
    }
    public void HealSound()
    {
        audio.volume = 0.1f;
        audio.clip = heal;
        audio.Play();
    }
    public void CastSound()
    {
        audio.volume = 0.1f;
        audio.clip = cast;
        audio.Play();
        
    }
    public void BuffSound()
    {
        audio.volume = 0.3f;
        audio.clip = buff;
        audio.Play();
    }
}
