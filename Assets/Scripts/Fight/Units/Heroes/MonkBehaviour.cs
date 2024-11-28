using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : BaseHeroBehaviour
{
    [SerializeField] private UnitStats unitStats;
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
        int attackPerTurn = 2;
        if (timesAttacked == attackPerTurn)
        {
            unitStats.currentSpellSlots -= 1;

            FightManager.Instance.HeroEndTurn();
        }
        enemy.unitStats.TakeDamage((unitStats.damage));
        timesAttacked++;
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
        unitStats.maxHealth = MonkStats.Instance.maxHealth;
        unitStats.currentHealth = MonkStats.Instance.currentHealth;
        unitStats.damage = MonkStats.Instance.damage;
        unitStats.maxSpellSlots = MonkStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = MonkStats.Instance.currentSpellSlots;
        unitStats.healModifier = MonkStats.Instance.healModifier;
        unitStats.isAlive = MonkStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        MonkStats.Instance.currentHealth = unitStats.currentHealth;   
        MonkStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        MonkStats.Instance.isAlive = unitStats.isAlive;
    }
}
