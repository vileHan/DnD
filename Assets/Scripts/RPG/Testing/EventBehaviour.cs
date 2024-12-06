using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventBehaviour : MonoBehaviour
{

    public static event Action<PortalState> OnPortalStateChanged;
    private int eventIndex;
    // Start is called before the first frame update
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
            eventIndex = UnityEngine.Random.Range(0, 4);
        }

        switch(eventIndex)
        {
            case 0:
                HandleLootEvent();
                break;
            case 1:
                HandleLootOrNotEvent();
                break;
            case 2:
                HandleFightOrNotEvent();
                break;
            case 3:
                HandleChanceOrNotEvent();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(eventIndex), eventIndex, null);
        }
        gameObject.SetActive(false);  
    } 

    void HandleLootEvent()
    {
        int reward = 5;
        PlayerStats.Instance.gold += reward;
        Debug.Log("You find " + reward + "g");
    }
    void HandleLootOrNotEvent()
    {
        int reward = 8;
        PlayerStats.Instance.gold += reward;
        Debug.Log("Choose between (looting + damage) and running");
        Debug.Log("You find " + reward + "g");
    }
    void HandleFightOrNotEvent()
    {
        int reward = 0;
        PlayerStats.Instance.gold += reward;
        Debug.Log("Choose between (looting + fight) and running");
        Debug.Log("You find " + reward + "g");
    }
    void HandleChanceOrNotEvent()
    {
        int reward = UnityEngine.Random.Range(0,11);
        PlayerStats.Instance.gold += reward;
        Debug.Log("Choose between event(loot/fight/damage) and running");
        Debug.Log("You find " + reward + "g");
    }
}

public enum PortalState
    {
        Loot,
        LootOrNot,
        LootOrFight,
        DamageOrNot,
        FightOrNot
    }
