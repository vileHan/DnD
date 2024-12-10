using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : BaseHeroBehaviour
{
    [SerializeField] private TargetableUnit targetableUnit;
    [SerializeField] private SpellSlotHandler spellslotHandler;
    [SerializeField] private KnightAnimationScript knightAnimationScript;

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
        target.TakeDamage(targetableUnit.damage);
        knightAnimationScript.Attack1Animation();

        FightManager.Instance.HeroEndTurn();        
    }
    public override void SecondaryAttack(TargetableUnit target)
    {
        // Deal damage to the 
        target.TakeDamage(targetableUnit.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void Spell_1Against(TargetableUnit target) // MAYBE WEIRD AFTER CHANGES
    {
        for (int i = 0; i < UnitManager.Instance.heroesAlive.Count; i++)
        {
            TargetableUnit targetStats = UnitManager.Instance.heroesAlive[i].GetComponent<TargetableUnit>();
            targetStats.Heal((targetableUnit.healModifier));
            knightAnimationScript.Cast2Animation();
        }
        targetableUnit.currentSpellSlots -= 1;
        spellslotHandler.UpdateSpellslots();

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_2Against(TargetableUnit target)
    {        
        int attackPerTurn = 2;
        if (timesAttacked == attackPerTurn)
        {
            targetableUnit.currentSpellSlots -= 1;
            spellslotHandler.UpdateSpellslots();
            timesAttacked = 0;

            FightManager.Instance.HeroEndTurn();
        }
        target.TakeDamage((targetableUnit.damage));
        knightAnimationScript.Attack1Animation();
        timesAttacked++;
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
        targetableUnit.maxHealth = MonkStats.Instance.maxHealth;
        targetableUnit.currentHealth = MonkStats.Instance.currentHealth;
        targetableUnit.damage = MonkStats.Instance.damage;
        targetableUnit.maxSpellSlots = MonkStats.Instance.maxSpellSlots;
        targetableUnit.currentSpellSlots = MonkStats.Instance.currentSpellSlots;
        targetableUnit.healModifier = MonkStats.Instance.healModifier;
        targetableUnit.isAlive = MonkStats.Instance.isAlive;
        targetableUnit.panelIndex = MonkStats.Instance.panelIndex;
        targetableUnit.armor = MonkStats.Instance.armor;
        targetableUnit.test = MonkStats.Instance.armor;
    }
    public void SaveStats() // make this a list or something
    {
        MonkStats.Instance.currentHealth = targetableUnit.currentHealth;     
        MonkStats.Instance.isAlive = targetableUnit.isAlive;
    }
}
