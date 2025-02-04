using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBehaviour : MonoBehaviour
{
    [SerializeField] private int eventIndex;
    public GameObject interactableObject;
    public GameObject interactPanel;
    bool isAbleToInteract;

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
                Debug.Log("interact3");
                playerAnimationSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnimationSounds>();
                playerAnimationSounds.interactableObject = interactableObject;
                EventTriggerManager.Instance.UpdateEvent(EventState.ChanceOrNot);
                gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactPanel.SetActive(true);
            isAbleToInteract = true;
            // switch(eventIndex)
            // {
            //     case 0:
            //         interactPanel.SetActive(true);
            //         isAbleToInteract = true;
            //         break;
            //     case 1:
            //         EventTriggerManager.Instance.UpdateEvent(EventState.LootOrNot);
            //         break;
            //     case 2:
            //         EventTriggerManager.Instance.UpdateEvent(EventState.FightOrNot);
            //         break;
            //     case 3:
            //         EventTriggerManager.Instance.UpdateEvent(EventState.ChanceOrNot);
            //         break;
            //     default:
            //         throw new ArgumentOutOfRangeException(nameof(eventIndex), eventIndex, null);
            // }
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
}


