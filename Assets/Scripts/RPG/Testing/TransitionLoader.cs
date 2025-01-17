using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLoader : MonoBehaviour
{

    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        GameManager.Instance.StartGame();
    }
}
