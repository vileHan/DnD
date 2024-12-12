using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehaviour : BaseHeroBehaviour
{
    [SerializeField] private TargetableUnit targetableUnit;
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
        this.target = target;
        
        knightAnimationScript.Attack1Animation();
       
    }
    public override void SecondaryAttack(TargetableUnit target)
    {
        this.target = target;

        // Deal damage to the 
        target.TakeDamage(targetableUnit.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void Spell_1Against(TargetableUnit target)
    {
        this.target = target;

        knightAnimationScript.Attack3Animation();
        targetableUnit.armor += 5;

        targetableUnit.currentSpellSlots -= 1;
        spellslotHandler.UpdateSpellslots();
    }
    public override void Spell_2Against(TargetableUnit target)
    {
        this.target = target;

        target.Heal((targetableUnit.healModifier));
        targetableUnit.Heal(targetableUnit.healModifier);
        knightAnimationScript.BlockAnimation();

        targetableUnit.currentSpellSlots -= 1;
        spellslotHandler.UpdateSpellslots();

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
        targetableUnit.maxHealth = PaladinStats.Instance.maxHealth;
        targetableUnit.currentHealth = PaladinStats.Instance.currentHealth;
        targetableUnit.damage = PaladinStats.Instance.damage;
        targetableUnit.maxSpellSlots = PaladinStats.Instance.maxSpellSlots;
        targetableUnit.currentSpellSlots = PaladinStats.Instance.currentSpellSlots;
        targetableUnit.healModifier = PaladinStats.Instance.healModifier;
        targetableUnit.isAlive = PaladinStats.Instance.isAlive;
        targetableUnit.panelIndex = PaladinStats.Instance.panelIndex;
        targetableUnit.armor = PaladinStats.Instance.armor;
    }
    public void SaveStats() // make this a list or something
    {
        PaladinStats.Instance.currentHealth = targetableUnit.currentHealth;    
        PaladinStats.Instance.isAlive = targetableUnit.isAlive;
    }
}
