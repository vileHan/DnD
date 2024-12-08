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

    public GameObject HeroStatManager;
    private MonkStats monkStats;
    private PaladinStats paladinStats;
    private RogueStats rogueStats;
    private WizardStats wizardStats;

    public static event Action<EventState> OnEventStateChanged;

    void Awake()
    {
        Instance = this;

    }
    void Start()
    {
        monkStats = HeroStatManager.GetComponent<MonkStats>();
        paladinStats = HeroStatManager.GetComponent<PaladinStats>();
        rogueStats = HeroStatManager.GetComponent<RogueStats>();
        wizardStats = HeroStatManager.GetComponent<WizardStats>();

        for (int i = 0; i < level; i++)
        {
            GameObject temp = Instantiate(portal[UnityEngine.Random.Range(0, portal.Length)], new Vector3(0f, 2.5f, spawnZ + (i * 15)), Quaternion.identity);
            trigger.Add(temp);
            trigger[i].transform.SetParent(this.transform, true);
        }
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
        Debug.Log("Fight " + difficulty + " ememies");
    }
    public void ReceiveDamageEvent(float damage)
    {
        monkStats.currentHealth -= damage;
        paladinStats.currentHealth -= damage;
        rogueStats.currentHealth -= damage;
        wizardStats.currentHealth -= damage;
        Debug.Log("Your party received " + damage + " damage");
    }
    public void ReceiveGoldEvent(float min, float max)
    {
        float reward = UnityEngine.Random.Range(min, max);
        PlayerStats.Instance.gold += (int)reward;
        Debug.Log("You found " + reward + "g");
    }
}

public enum EventState
    {
        Loot,
        LootOrNot,
        FightOrNot,
        ChanceOrNot
    }
