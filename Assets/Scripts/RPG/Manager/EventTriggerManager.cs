using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EventTriggerManager : MonoBehaviour
{
    public static EventTriggerManager Instance;
    public Animator playerAnimator;
    int level = 6;
    public GameObject[] portal; 
    public GameObject lootPanel, lootOrNotPanel, fightOrNotPanel, chanceOrNotPanel, eventLogPanel;
    public List<GameObject> trigger;
    private float spawnZ = -30;
    public int eventLogIndex;
    public float reward;

    public AudioSource audio;
    public AudioClip money, buff, damage;


    public static event Action<EventState> OnEventStateChanged;

    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        // for (int i = 0; i < level; i++)
        // {
        //     GameObject temp = Instantiate(portal[UnityEngine.Random.Range(0, portal.Length)], new Vector3(0f, 2.5f, spawnZ + (i * 15)), Quaternion.identity);
        //     trigger.Add(temp);
        //     trigger[i].transform.SetParent(this.transform, true);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetPortals()
    {
        for (int i = 0; i < trigger.Count; i++)
        {
            trigger[i].SetActive(true);
        }
        
    }
    public void UpdateEvent(EventState newEvent)
    {
        OnEventStateChanged?.Invoke(newEvent);

        switch(newEvent)
        {
            case EventState.Loot:
                HandleLootEvent();
                break;
            case EventState.LootOrNot:
                HandleLootOrNotEvent();
                break;
            case EventState.FightOrNot:
                HandleFightOrNotEvent();
                break;
            case EventState.ChanceOrNot:
                HandleChanceOrNotEvent();
                break;
            case EventState.OpenDoor:
                OpenDoorEvent();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newEvent), newEvent, null);
        }
    }
    
    void HandleLootEvent()
    {
        playerAnimator.SetTrigger("grabbing item");      // --> check button events
    }
    void HandleLootOrNotEvent()
    {
        lootOrNotPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void HandleFightOrNotEvent()
    {
        fightOrNotPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void HandleChanceOrNotEvent()
    {
        playerAnimator.SetTrigger("interacting");
    }
    void OpenDoorEvent()
    {
        playerAnimator.SetTrigger("open door");
    }

    public void TriggerFightEvent(int difficulty)
    {
        GameManager.Instance.difficulty = difficulty;
        GameManager.Instance.StartCoroutine(GameManager.Instance.PlayInitiateFight());
        eventLogIndex = 0;
    }
    public void ReceiveDamageEvent(float damage)
    {
        if (MonkStats.Instance != null) // should check all but im too lazy right now and i should make a script that connects all stats(which would then make this task easier)
        {
            MonkStats.Instance.currentHealth -= damage;
            PaladinStats.Instance.currentHealth -= damage;
            RogueStats.Instance.currentHealth -= damage;
            WizardStats.Instance.currentHealth -= damage;
        }
        PlayDamageSound();
        eventLogPanel.SetActive(true);
        eventLogIndex = 3;
        
    }
    public void UpgradeDamageEvent(float damage)
    {
        if (MonkStats.Instance != null) // should check all but im too lazy right now and i should make a script that connects all stats(which would then make this task easier)
        {
            MonkStats.Instance.damage += damage;
            PaladinStats.Instance.damage += damage;
            RogueStats.Instance.damage += damage;
            WizardStats.Instance.damage += damage;
        }
        PlayBuffSound();
        eventLogPanel.SetActive(true);
        eventLogIndex = 1;

    }
    public void ReceiveGoldEvent(float min, float max)
    {
        if (PlayerStats.Instance != null) // should check all but im too lazy right now and i should make a script that connects all stats(which would then make this task easier)
        {
            reward = UnityEngine.Random.Range(min, max);
            PlayerStats.Instance.gold += (int)reward;   
        }
        PlayMoneySound();
        eventLogPanel.SetActive(true);
        eventLogIndex = 2;
    }

    void PlayMoneySound()
    {
        audio.clip = money;
        audio.Play();
    }
    void PlayBuffSound()
    {
        audio.clip = buff;
        audio.Play();
    }
    void PlayDamageSound()
    {
        audio.clip = damage;
        audio.Play();
    }
}

public enum EventState
    {
        Loot,
        LootOrNot,
        FightOrNot,
        ChanceOrNot,
        OpenDoor      
    }
