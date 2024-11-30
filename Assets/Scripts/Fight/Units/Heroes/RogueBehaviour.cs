using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RogueBehaviour : BaseHeroBehaviour
{
    [SerializeField] private HeroStats heroStats;
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
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void PrimaryAttack(TargetableUnit target)
    {
        // Deal damage to the 
        target.TakeDamage(heroStats.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void SecondaryAttack(TargetableUnit target)
    {
        // Deal damage to the 
        target.TakeDamage(heroStats.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void Spell_1Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));
        
        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_2Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));
        heroStats.currentSpellSlots -= 1;

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_3Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_4Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_5Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_6Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_7Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_8Against(TargetableUnit target)
    {
        target.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }

    void SetStats() // make this a list or something
    {
        heroStats.maxHealth = RogueStats.Instance.maxHealth;
        heroStats.currentHealth = RogueStats.Instance.currentHealth;
        heroStats.damage = RogueStats.Instance.damage;
        heroStats.maxSpellSlots = RogueStats.Instance.maxSpellSlots;
        heroStats.currentSpellSlots = RogueStats.Instance.currentSpellSlots;
        heroStats.healModifier = RogueStats.Instance.healModifier;
        heroStats.isAlive = RogueStats.Instance.isAlive;
        heroStats.panelIndex = RogueStats.Instance.panelIndex;
    }
    public void SaveStats() // make this a list or something
    {
        RogueStats.Instance.currentHealth = heroStats.currentHealth;   
        RogueStats.Instance.currentSpellSlots = heroStats.currentSpellSlots; 
        RogueStats.Instance.isAlive = heroStats.isAlive; 
    }
}
