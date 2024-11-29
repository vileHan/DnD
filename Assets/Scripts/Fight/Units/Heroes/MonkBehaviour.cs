using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : BaseHeroBehaviour
{
    [SerializeField] private HeroStats heroStats;
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
        enemy.unitStats.TakeDamage(heroStats.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void SecondaryAttackEnemy(EnemyBehaviour enemy)
    {
        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(heroStats.damage);

        FightManager.Instance.HeroEndTurn();        
    }
    public override void Spell_1AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));
        
        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_2AgainstEnemy(EnemyBehaviour enemy)
    {        
        int attackPerTurn = 2;
        if (timesAttacked == attackPerTurn)
        {
            heroStats.currentSpellSlots -= 1;

            FightManager.Instance.HeroEndTurn();
        }
        enemy.unitStats.TakeDamage((heroStats.damage));
        timesAttacked++;
    }
    public override void Spell_3AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_4AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_5AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_6AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_7AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));

        FightManager.Instance.HeroEndTurn();
    }
    public override void Spell_8AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((heroStats.damage*2));

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
    }
    public void SaveStats() // make this a list or something
    {
        MonkStats.Instance.currentHealth = heroStats.currentHealth;   
        MonkStats.Instance.currentSpellSlots = heroStats.currentSpellSlots;  
        MonkStats.Instance.isAlive = heroStats.isAlive;
    }
}
