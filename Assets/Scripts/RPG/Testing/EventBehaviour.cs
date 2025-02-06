using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBehaviour : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip notPossible;
    [SerializeField] private int eventIndex;
    public GameObject interactableObject;
    public GameObject interactPanel;
    bool isAbleToInteract;
    bool isAllowedToOpen = true;

    private PlayerAnimationSounds playerAnimationSounds;
    
    void Awake()
    {
        EventTriggerManager.OnEventStateChanged += EventTriggerManagerOnEventStateChanged;
    }
    void OnDestroy()
    {
        EventTriggerManager.OnEventStateChanged -= EventTriggerManagerOnEventStateChanged;
    }
    void EventTriggerManagerOnEventStateChanged(EventState state)
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAbleToInteract && Input.GetKeyDown(KeyCode.F))
        {
            interactPanel.SetActive(false);
            if (eventIndex == 0)
            {
                playerAnimationSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationSounds>();
                playerAnimationSounds.interactableObject = interactableObject;
                EventTriggerManager.Instance.UpdateEvent(EventState.Loot);
                gameObject.SetActive(false);
            }
            if (eventIndex == 1)
            {
                EventTriggerManager.Instance.UpdateEvent(EventState.LootOrNot);
                gameObject.SetActive(false);
            }
            if (eventIndex == 2)
            {
                EventTriggerManager.Instance.UpdateEvent(EventState.FightOrNot);
                gameObject.SetActive(false);
            }
            if (eventIndex == 3)
            {
                playerAnimationSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationSounds>();
                playerAnimationSounds.interactableObject = interactableObject;
                EventTriggerManager.Instance.UpdateEvent(EventState.ChanceOrNot);
                gameObject.SetActive(false);
            }
            if (eventIndex == 4)
            {
                if (isAllowedToOpen)
                {
                    playerAnimationSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationSounds>();
                    playerAnimationSounds.interactableObject = interactableObject;
                    EventTriggerManager.Instance.UpdateEvent(EventState.OpenDoor);
                    gameObject.SetActive(false);
                }
                else
                {
                    PlayNotPossibleSound();
                    EventTriggerManager.Instance.eventLogPanel.SetActive(true);
                    EventTriggerManager.Instance.eventLogIndex = 4;
                }
                
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactPanel.SetActive(true);
            isAbleToInteract = true;
        }
        //gameObject.SetActive(false);  
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactPanel.SetActive(false);
            isAbleToInteract = false;
        } 
    } 

    public void PlayNotPossibleSound()
    {
        //audio.clip = notPossible;
        GetComponent<AudioSource>().PlayOneShot(notPossible);
    }
}


