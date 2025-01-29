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
    int level = 6;
    public GameObject[] portal; 
    public GameObject lootPanel, lootOrNotPanel, fightOrNotPanel, chanceOrNotPanel;
    public List<GameObject> trigger;
    private float spawnZ = -30;
    public int eventLogIndex;
    public float reward;


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
            default:
                throw new ArgumentOutOfRangeException(nameof(newEvent), newEvent, null);
        }
    }
    
    void HandleLootEvent()
    {
        lootPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
        chanceOrNotPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void TriggerFightEvent(int difficulty)
    {
        GameManager.Instance.DisableRPGScene();
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        GameManager.Instance.difficulty = difficulty;
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
        eventLogIndex = 1;
    }
    public void ReceiveGoldEvent(float min, float max)
    {
        if (PlayerStats.Instance != null) // should check all but im too lazy right now and i should make a script that connects all stats(which would then make this task easier)
        {
            reward = UnityEngine.Random.Range(min, max);
            PlayerStats.Instance.gold += (int)reward;   
        }
        eventLogIndex = 2;
    }
}

public enum EventState
    {
        Loot,
        LootOrNot,
        FightOrNot,
        ChanceOrNot        
    }
