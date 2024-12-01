using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : BaseHeroBehaviour
{
    [SerializeField] private HeroStats heroStats;
    [SerializeField] private SpellSlotHandler spellslotHandler;

    private int timesAttacked = 1;
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
        int attackPerTurn = 2;
        if (timesAttacked == attackPerTurn)
        {
            heroStats.currentSpellSlots -= 1;
            spellslotHandler.UpdateSpellslots();

            FightManager.Instance.HeroEndTurn();
        }
        target.TakeDamage((heroStats.damage));
        timesAttacked++;
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
        heroStats.maxHealth = MonkStats.Instance.maxHealth;
        heroStats.currentHealth = MonkStats.Instance.currentHealth;
        heroStats.damage = MonkStats.Instance.damage;
        heroStats.maxSpellSlots = MonkStats.Instance.maxSpellSlots;
        heroStats.currentSpellSlots = MonkStats.Instance.currentSpellSlots;
        heroStats.healModifier = MonkStats.Instance.healModifier;
        heroStats.isAlive = MonkStats.Instance.isAlive;
        heroStats.panelIndex = MonkStats.Instance.panelIndex;
    }
    public void SaveStats() // make this a list or something
    {
        MonkStats.Instance.currentHealth = heroStats.currentHealth;   
        MonkStats.Instance.currentSpellSlots = heroStats.currentSpellSlots;  
        MonkStats.Instance.isAlive = heroStats.isAlive;
    }
}
