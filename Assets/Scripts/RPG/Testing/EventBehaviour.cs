using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBehaviour : MonoBehaviour
{
    [SerializeField] private int eventIndex;
    
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
        
    }

     public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch(eventIndex)
            {
                case 0:
                    EventTriggerManager.Instance.UpdateEvent(EventState.Loot);
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
        gameObject.SetActive(false);  
    } 
}


