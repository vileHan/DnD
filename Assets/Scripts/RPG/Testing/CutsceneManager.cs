using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    PlayableDirector director;
    public PlayableAsset[] cutscene;
    public static CutsceneManager Instance;

    public bool isCutscenePlaying;

    void Awake()
    {
        Instance = this;
        director = GetComponent<PlayableDirector>();
    }

    public void PlayCutsceneDoor()
    {
        StartCoroutine(HandleCutscene(1));
    }

    IEnumerator HandleCutscene(int cutsceneIndex)
    {
        if (cutsceneIndex == 1)
        {
            director.playableAsset = cutscene[0];
        }

        director.Play();

        isCutscenePlaying = true;

        yield return new WaitUntil(() => director.state != PlayState.Playing);

        isCutscenePlaying = false;
    }
}
