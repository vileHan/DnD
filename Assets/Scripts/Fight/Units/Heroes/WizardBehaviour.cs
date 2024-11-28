using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : BaseHeroBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    void Awake()
    {
        SetStats();
        FightUIManager.OnActionStateChanged += FightUIManagerOnActionStateChanged;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightUIManager.OnActionStateChanged -= FightUIManagerOnActionStateChanged;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state)
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
    private void FightUIManagerOnActionStateChanged(ActionState state)
    {
        if (state == ActionState.Attack)
        {
            FightManager.Instance.heroAttackingIndex = 1;
        }
        if (state == ActionState.Skill_2)
        {
            FightManager.Instance.heroAttackingIndex = 4;
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

    public override void PrimaryAttackEnemy(EnemyBehaviour enemy)
    {
        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(unitStats.damage);

        FightUIManager.Instance.HeroEndTurn();        
    }
    public override void Skill_2AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }
    public override void Skill_3AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }
    public override void Skill_4AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }
    public override void Skill_5AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }
    public override void Skill_6AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }
    public override void Skill_7AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }
    public override void Skill_8AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightUIManager.Instance.HeroEndTurn();
    }

    void SetStats() // make this a list or something
    {
        unitStats.maxHealth = WizardStats.Instance.maxHealth;
        unitStats.currentHealth = WizardStats.Instance.currentHealth;
        unitStats.damage = WizardStats.Instance.damage;
        unitStats.maxSpellSlots = WizardStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = WizardStats.Instance.currentSpellSlots;
        unitStats.healModifier = WizardStats.Instance.healModifier;
        unitStats.isAlive = WizardStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        WizardStats.Instance.currentHealth = unitStats.currentHealth;   
        WizardStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        WizardStats.Instance.isAlive = unitStats.isAlive;
    }
}
