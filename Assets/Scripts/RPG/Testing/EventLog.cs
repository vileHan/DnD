using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EventLog : MonoBehaviour
{
    public TMP_Text eventLogText;
    public Animator animator;
    public AudioSource audio;
    public AudioClip money, buff, damage;
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(EventTriggerManager.Instance.eventLogIndex)
        {
            case 0:
                DisablePanel();
                break;
            case 1:
                eventLogText.color = Color.green;
                audio.clip = buff;
                eventLogText.text = "Each party member gains 5 damage!";
                animator.SetTrigger("Fadeaway");
                break;
            case 2:
                eventLogText.color = Color.green;
                audio.clip = money;
                eventLogText.text = "You receive " + (int)EventTriggerManager.Instance.reward + " gold.";
                animator.SetTrigger("Fadeaway");
                break;
            case 3:
                eventLogText.color = Color.red;
                audio.clip = damage;
                eventLogText.text = "Your party took 10 damage";
                animator.SetTrigger("Fadeaway");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(EventTriggerManager.Instance.eventLogIndex), EventTriggerManager.Instance.eventLogIndex, null);
        }
    }

    public void DisablePanel()
    {
        gameObject.SetActive(false);
    }

    public void PlayEventLogSound()
    {
        if (audio.clip == money)
        {
            audio.volume = 0.3f;
        }
        audio.Play();
    }
}
