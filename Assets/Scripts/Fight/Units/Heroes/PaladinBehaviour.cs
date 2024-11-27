using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehaviour : MonoBehaviour
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
        unitStats.maxHealth = PaladinStats.Instance.maxHealth;
        unitStats.currentHealth = PaladinStats.Instance.currentHealth;
        unitStats.damage = PaladinStats.Instance.damage;
        unitStats.maxSpellSlots = PaladinStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = PaladinStats.Instance.currentSpellSlots;
        unitStats.healModifier = PaladinStats.Instance.healModifier;
        unitStats.isAlive = PaladinStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        PaladinStats.Instance.currentHealth = unitStats.currentHealth;   
        PaladinStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        PaladinStats.Instance.isAlive = unitStats.isAlive;
    }
}
