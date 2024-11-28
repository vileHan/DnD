using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : BaseHeroBehaviour
{
    [SerializeField] private UnitStats unitStats;

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

    public override void PrimaryAttackEnemy(EnemyBehaviour enemy)
    {
        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(unitStats.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void SecondaryAttackEnemy(EnemyBehaviour enemy)
    {
        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(unitStats.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void Spell_1AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_2AgainstEnemy(EnemyBehaviour enemy)
    {
        for (int i = 0; i < UnitManager.Instance.enemiesAlive.Count; i++)
        {
            UnitStats targetStats = UnitManager.Instance.enemiesAlive[i].GetComponent<UnitStats>();
            targetStats.TakeDamage((int)(unitStats.damage/2));
        }
        unitStats.currentSpellSlots -= 1;

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_3AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_4AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_5AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_6AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_7AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_8AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));

        FightManager.Instance.HeroEndTurn();
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
