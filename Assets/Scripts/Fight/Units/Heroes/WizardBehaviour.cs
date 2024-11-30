using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : BaseHeroBehaviour
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
        for (int i = 0; i < UnitManager.Instance.enemiesAlive.Count; i++)
        {
        UnitStats targetStats = UnitManager.Instance.enemiesAlive[i].GetComponent<UnitStats>();
            targetStats.TakeDamage((heroStats.damage/2));
        }
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
        heroStats.maxHealth = WizardStats.Instance.maxHealth;
        heroStats.currentHealth = WizardStats.Instance.currentHealth;
        heroStats.damage = WizardStats.Instance.damage;
        heroStats.maxSpellSlots = WizardStats.Instance.maxSpellSlots;
        heroStats.currentSpellSlots = WizardStats.Instance.currentSpellSlots;
        heroStats.healModifier = WizardStats.Instance.healModifier;
        heroStats.isAlive = WizardStats.Instance.isAlive;
        heroStats.panelIndex = WizardStats.Instance.panelIndex;
    }
    public void SaveStats() // make this a list or something
    {
        WizardStats.Instance.currentHealth = heroStats.currentHealth;   
        WizardStats.Instance.currentSpellSlots = heroStats.currentSpellSlots;  
        WizardStats.Instance.isAlive = heroStats.isAlive;
    }
}
