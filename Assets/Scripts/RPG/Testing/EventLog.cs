using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class EventLog : MonoBehaviour
{
    public TMP_Text eventLogText, eventLogText_2;
    private Animator animator;

    private bool isPlaying;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(EventTriggerManager.Instance.eventLogIndex)
        {
            case 0:
                eventLogText.color = Color.green;      
                eventLogText.text = "+" + FightManager.Instance.fightGoldReward +"g";

                eventLogText_2.color = Color.white;      
                eventLogText_2.text = "+" + FightManager.Instance.fightExpReward + "exp";

                TextPositionRight();

                animator.SetTrigger("Fadeaway");
                break;
            case 1:
                eventLogText.color = Color.green;      
                eventLogText.text = "+5 ad";


                TextPositionRight();

                animator.SetTrigger("Fadeaway");
                break;
            case 2:
                eventLogText.color = Color.green;
                eventLogText.text = "+" + (int)EventTriggerManager.Instance.reward + "g";

                TextPositionRight();

                animator.SetTrigger("Fadeaway");
                break;
            case 3:
                eventLogText.color = Color.red;
                eventLogText.text = "-10 hp";

                TextPositionRight();

                animator.SetTrigger("Fadeaway");
                break;
            case 4:
                eventLogText.color = Color.white;
                eventLogText.text = "The door does not open yet.";

                TextPositionMiddle();
                
                animator.SetTrigger("Fadeaway");
                isPlaying = true;
                break;
            case 5:
                Debug.Log("i cant remember what this was for. if triggered go to eventlog case 5");
                eventLogText.color = Color.green;      
                eventLogText.text = "i cant remember what this was for. if triggered go to eventlog case 5";
                animator.SetTrigger("Fadeaway");
                break;
            default:
                break;
        }
    }

    public void DisablePanel()
    {
        gameObject.SetActive(false);
    }
    public void EmptyText()
    {
        eventLogText.text = "";
        eventLogText_2.text = "";

        EventTriggerManager.Instance.eventLogIndex = -1;
    }
    
    public void TextPositionMiddle()
    {
        RectTransform rectTransform = eventLogText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, 300);
    }
    public void TextPositionRight()
    {
        RectTransform rectTransform = eventLogText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(650, -50);
    }
}
