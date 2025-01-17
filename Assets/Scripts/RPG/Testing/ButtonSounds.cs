using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip mouseOver, mouseClick;
    private float time = 1f;
    
    public void MouseOverSound()
    {
        audio.clip = mouseOver;
        audio.Play();
    }
    public void MouseClickSound()
    {
        audio.clip = mouseClick;
        audio.Play();
        StartCoroutine(Wait(time));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
