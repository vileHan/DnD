using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehaviour : BaseHeroBehaviour
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
        enemy.unitStats.TakeDamage((heroStats.damage*2));
        heroStats.currentSpellSlots -= 1;

        FightManager.Instance.HeroEndTurn();
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
        heroStats.maxHealth = PaladinStats.Instance.maxHealth;
        heroStats.currentHealth = PaladinStats.Instance.currentHealth;
        heroStats.damage = PaladinStats.Instance.damage;
        heroStats.maxSpellSlots = PaladinStats.Instance.maxSpellSlots;
        heroStats.currentSpellSlots = PaladinStats.Instance.currentSpellSlots;
        heroStats.healModifier = PaladinStats.Instance.healModifier;
        heroStats.isAlive = PaladinStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        PaladinStats.Instance.currentHealth = heroStats.currentHealth;   
        PaladinStats.Instance.currentSpellSlots = heroStats.currentSpellSlots;  
        PaladinStats.Instance.isAlive = heroStats.isAlive;
    }
}
