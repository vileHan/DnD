using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioSource ambientSource;
    public AudioClip[] playlist;
    public AudioClip wind;
    public int currentTrackIndex = 0;  
    public float crossfadeDuration = 1.0f;

    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (playlist.Length > 0)
        {
            PlayTrack(currentTrackIndex);
        }
        ambientSource.clip = wind;
        ambientSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // if (!audioSource.isPlaying && playlist.Length > 0)
        // {
        //     StartCoroutine(CrossfadeToNextTrack());
        // }
    }

    public void PlayTrack(int index)
    {
        if (index >= 0 && index < playlist.Length)
        {
            audioSource.clip = playlist[index];
            audioSource.Play();
        }
    }

    public void StopTrack(int index)
    {
        audioSource.clip = playlist[index];
        audioSource.Stop();
    }

    IEnumerator CrossfadeToNextTrack()
    {
        float startVolume = audioSource.volume;

        // Fade out the current track
        for (float t = 0; t < crossfadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / crossfadeDuration);
            yield return null;
        }
        audioSource.volume = 0;

        // Play the next track
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length; // Loop back to the first track
        PlayTrack(currentTrackIndex);

        // Fade in the new track
        for (float t = 0; t < crossfadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / crossfadeDuration);
            yield return null;
        }
        audioSource.volume = startVolume;
    }
}
