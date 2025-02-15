using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionLoader : MonoBehaviour
{
    public static TransitionLoader Instance;
    public Animator anim;
    private Image panelImage;

    // Update is called once per frame
    void Awake()
    {
        Instance = this;
        if (panelImage != null)
        {   
            panelImage = gameObject.GetComponent<Image>();
        }
        
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

    public void StartTransition()
    {
        if (anim != null)
        {
            anim.enabled = true;
            anim.Play("Fadein_Solo");
        }
        
    }
    public void EndTransition()
    {
        if (anim != null)
        {
            anim.enabled = true;
            Debug.Log("testfadeout");
            anim.Play("Fadeout_Solo");
        }
    }
    public void StopTransition()
    {
        //anim.enabled = false;
        Debug.Log("test"); // not working without for some reason
    }
}
