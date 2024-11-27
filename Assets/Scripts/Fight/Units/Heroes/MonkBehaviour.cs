using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    void Awake()
    {
        SetStats();
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.FightWon)
        {
            SaveStats();
        }
        if (state == GameState.FightLost)
        {
            //pokecenter
        }
    }

    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitStats.isTurn)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }

    void SetStats() // make this a list or something
    {
        unitStats.maxHealth = MonkStats.Instance.maxHealth;
        unitStats.currentHealth = MonkStats.Instance.currentHealth;
        unitStats.damage = MonkStats.Instance.damage;
        unitStats.maxSpellSlots = MonkStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = MonkStats.Instance.currentSpellSlots;
        unitStats.healModifier = MonkStats.Instance.healModifier;
        unitStats.isAlive = MonkStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        MonkStats.Instance.currentHealth = unitStats.currentHealth;   
        MonkStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        MonkStats.Instance.isAlive = unitStats.isAlive;
    }
}
