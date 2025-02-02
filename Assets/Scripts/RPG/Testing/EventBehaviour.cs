using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBehaviour : MonoBehaviour
{
    [SerializeField] private int eventIndex;
    public GameObject lootableObject;
    public GameObject interactPanel;
    bool isAbleToInteract;
    
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
                EventTriggerManager.Instance.UpdateEvent(EventState.Loot);
                if (lootableObject != null)
                {
                    lootableObject.SetActive(false);
                }
                gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch(eventIndex)
            {
                case 0:
                    interactPanel.SetActive(true);
                    isAbleToInteract = true;
                    // EventTriggerManager.Instance.UpdateEvent(EventState.Loot);
                    // if (lootableObject != null)
                    // {
                    //     lootableObject.SetActive(false);
                    // }
                    break;
                case 1:
                    EventTriggerManager.Instance.UpdateEvent(EventState.LootOrNot);
                    break;
                case 2:
                    EventTriggerManager.Instance.UpdateEvent(EventState.FightOrNot);
                    break;
                case 3:
                    EventTriggerManager.Instance.UpdateEvent(EventState.ChanceOrNot);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventIndex), eventIndex, null);
            }
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


