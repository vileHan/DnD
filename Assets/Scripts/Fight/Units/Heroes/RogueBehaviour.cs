using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RogueBehaviour : BaseHeroBehaviour
{
    [SerializeField] private TargetableUnit targetableUnit;
    [SerializeField] private SpellSlotHandler spellslotHandler;
    
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
        target.TakeDamage(targetableUnit.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void SecondaryAttack(TargetableUnit target)
    {
        // Deal damage to the 
        target.TakeDamage(targetableUnit.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void Spell_1Against(TargetableUnit target)
    {
        targetableUnit.damage += 20;

        targetableUnit.currentSpellSlots -= 1;
        spellslotHandler.UpdateSpellslots();
        
        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_2Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*1.5f));

        targetableUnit.currentSpellSlots -= 1;
        spellslotHandler.UpdateSpellslots();

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_3Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_4Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_5Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_6Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_7Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_8Against(TargetableUnit target)
    {
        target.TakeDamage((targetableUnit.damage*2));

        FightManager.Instance.HeroEndTurn();
    }

    void SetStats() // make this a list or something
    {
        targetableUnit.maxHealth = RogueStats.Instance.maxHealth;
        targetableUnit.currentHealth = RogueStats.Instance.currentHealth;
        targetableUnit.damage = RogueStats.Instance.damage;
        targetableUnit.maxSpellSlots = RogueStats.Instance.maxSpellSlots;
        targetableUnit.currentSpellSlots = RogueStats.Instance.currentSpellSlots;
        targetableUnit.healModifier = RogueStats.Instance.healModifier;
        targetableUnit.isAlive = RogueStats.Instance.isAlive;
        targetableUnit.panelIndex = RogueStats.Instance.panelIndex;
        targetableUnit.armor = RogueStats.Instance.armor;
    }
    public void SaveStats() // make this a list or something
    {
        RogueStats.Instance.currentHealth = targetableUnit.currentHealth;    
        RogueStats.Instance.isAlive = targetableUnit.isAlive; 
    }
}
