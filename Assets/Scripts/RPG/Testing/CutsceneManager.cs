using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    PlayableDirector director;
    public static CutsceneManager Instance;

    void Awake()
    {
        Instance = this;
        director = GetComponent<PlayableDirector>();
    }

    public void PlayCutsceneDoor()
    {
        director.Play();
    }
}
