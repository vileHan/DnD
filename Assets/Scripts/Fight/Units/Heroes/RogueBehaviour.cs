using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    void Awake()
    {
        SetStats();
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
        unitStats.maxHealth = RogueStats.Instance.maxHealth;
        unitStats.currentHealth = RogueStats.Instance.currentHealth;
        unitStats.damage = RogueStats.Instance.damage;
        unitStats.maxSpellSlots = RogueStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = RogueStats.Instance.currentSpellSlots;
        unitStats.healModifier = RogueStats.Instance.healModifier;
        unitStats.isAlive = RogueStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        RogueStats.Instance.currentHealth = unitStats.currentHealth;   
        RogueStats.Instance.currentSpellSlots = unitStats.currentSpellSlots; 
        RogueStats.Instance.isAlive = unitStats.isAlive; 
    }
}
