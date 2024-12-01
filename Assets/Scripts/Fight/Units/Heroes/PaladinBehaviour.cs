using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehaviour : BaseHeroBehaviour
{
    [SerializeField] private HeroStats heroStats;
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
        target.Heal((heroStats.healModifier));
        heroStats.Heal(heroStats.healModifier);
        heroStats.currentSpellSlots -= 1;
        spellslotHandler.UpdateSpellslots();

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
        heroStats.maxHealth = PaladinStats.Instance.maxHealth;
        heroStats.currentHealth = PaladinStats.Instance.currentHealth;
        heroStats.damage = PaladinStats.Instance.damage;
        heroStats.maxSpellSlots = PaladinStats.Instance.maxSpellSlots;
        heroStats.currentSpellSlots = PaladinStats.Instance.currentSpellSlots;
        heroStats.healModifier = PaladinStats.Instance.healModifier;
        heroStats.isAlive = PaladinStats.Instance.isAlive;
        heroStats.panelIndex = PaladinStats.Instance.panelIndex;
    }
    public void SaveStats() // make this a list or something
    {
        PaladinStats.Instance.currentHealth = heroStats.currentHealth;   
        PaladinStats.Instance.currentSpellSlots = heroStats.currentSpellSlots;  
        PaladinStats.Instance.isAlive = heroStats.isAlive;
    }
}
