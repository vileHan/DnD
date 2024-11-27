using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehaviour : MonoBehaviour
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
        unitStats.maxHealth = PaladinStats.Instance.maxHealth;
        unitStats.currentHealth = PaladinStats.Instance.currentHealth;
        unitStats.damage = PaladinStats.Instance.damage;
        unitStats.maxSpellSlots = PaladinStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = PaladinStats.Instance.currentSpellSlots;
        unitStats.healModifier = PaladinStats.Instance.healModifier;
    }
    public void SaveStats() // make this a list or something
    {
        PaladinStats.Instance.currentHealth = unitStats.currentHealth;   
        PaladinStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
    }
}
