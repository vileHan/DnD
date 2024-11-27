using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : MonoBehaviour
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
        unitStats.maxHealth = WizardStats.Instance.maxHealth;
        unitStats.currentHealth = WizardStats.Instance.currentHealth;
        unitStats.damage = WizardStats.Instance.damage;
        unitStats.maxSpellSlots = WizardStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = WizardStats.Instance.currentSpellSlots;
        unitStats.healModifier = WizardStats.Instance.healModifier;
        unitStats.isAlive = WizardStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        WizardStats.Instance.currentHealth = unitStats.currentHealth;   
        WizardStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        WizardStats.Instance.isAlive = unitStats.isAlive;
    }
}
