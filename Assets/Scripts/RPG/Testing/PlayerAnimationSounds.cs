using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip footstepsSlow_1, footstepsSlow_2, footstepsFast_1, footstepsFast_2;

    public void FootstepSlow_1Sound()
    {
        audio.volume = 0.1f;
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsSlow_1;
        audio.Play();
    }
    public void FootstepSlow_2Sound()
    {
        audio.volume = 0.1f;
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsSlow_2;
        audio.Play();
    }

    public void FootstepFast_1Sound()
    {
        audio.volume = 0.1f;
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsFast_1;
        audio.Play();
    }
    public void FootstepFast_2Sound()
    {
        audio.volume = 0.1f;
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsFast_2;
        audio.Play();
    }
}
