using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
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
        SetStats();
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
    }
    public void SaveStats() // make this a list or something
    {
        WizardStats.Instance.currentHealth = unitStats.currentHealth;   
        WizardStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
    }
}
