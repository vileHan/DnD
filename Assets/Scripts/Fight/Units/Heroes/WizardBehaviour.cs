using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : BaseHeroBehaviour
{    [SerializeField] private TargetableUnit targetableUnit;
    [SerializeField] private SpellSlotHandler spellslotHandler;
    [SerializeField] private KnightAnimationScript knightAnimationScript;


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
    public override void Spell_1Against(TargetableUnit target) // targetable unit.currentspellslots! when implemented
    {
        target.TakeDamage((targetableUnit.damage));
        knightAnimationScript.Attack3Animation();

        targetableUnit.currentSpellSlots += 1;
        spellslotHandler.UpdateSpellslots();

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_2Against(TargetableUnit target)
    {
        int initialEnemyCount = UnitManager.Instance.enemiesAlive.Count;
        for (int i = 0; i < initialEnemyCount; i++)
        {
            if (i >= UnitManager.Instance.enemiesAlive.Count)
            {
                break;
            }
            TargetableUnit targetStats = UnitManager.Instance.enemiesAlive[i].GetComponent<TargetableUnit>();

            targetStats.TakeDamage((targetableUnit.damage/2));
            knightAnimationScript.Cast2Animation();
            
        }
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
        targetableUnit.maxHealth = WizardStats.Instance.maxHealth;
        targetableUnit.currentHealth = WizardStats.Instance.currentHealth;
        targetableUnit.damage = WizardStats.Instance.damage;
        targetableUnit.maxSpellSlots = WizardStats.Instance.maxSpellSlots;
        targetableUnit.currentSpellSlots = WizardStats.Instance.currentSpellSlots;
        targetableUnit.healModifier = WizardStats.Instance.healModifier;
        targetableUnit.isAlive = WizardStats.Instance.isAlive;
        targetableUnit.panelIndex = WizardStats.Instance.panelIndex;
        targetableUnit.armor = WizardStats.Instance.armor;
    }
    public void SaveStats() // make this a list or something
    {
        WizardStats.Instance.currentHealth = targetableUnit.currentHealth;     
        WizardStats.Instance.isAlive = targetableUnit.isAlive;
    }
}
