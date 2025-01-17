using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeDoorSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip shut, creaking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShutSound()
    {
        audio.pitch = 0.5f;
        audio.clip = shut;
        audio.Play();
    }
    public void CreakSound()
    {
        audio.volume = 0.05f;
        audio.clip = creaking;
        audio.Play();
    }
}
