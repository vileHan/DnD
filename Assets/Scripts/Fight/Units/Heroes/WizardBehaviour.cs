using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBehaviour : BaseHeroBehaviour
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
        for (int i = 0; i < UnitManager.Instance.enemiesAlive.Count; i++)
        {
            UnitStats targetStats = UnitManager.Instance.enemiesAlive[i].GetComponent<UnitStats>();
            targetStats.TakeDamage((heroStats.damage/2));
        }
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
        heroStats.maxHealth = WizardStats.Instance.maxHealth;
        heroStats.currentHealth = WizardStats.Instance.currentHealth;
        heroStats.damage = WizardStats.Instance.damage;
        heroStats.maxSpellSlots = WizardStats.Instance.maxSpellSlots;
        heroStats.currentSpellSlots = WizardStats.Instance.currentSpellSlots;
        heroStats.healModifier = WizardStats.Instance.healModifier;
        heroStats.isAlive = WizardStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        WizardStats.Instance.currentHealth = heroStats.currentHealth;   
        WizardStats.Instance.currentSpellSlots = heroStats.currentSpellSlots;  
        WizardStats.Instance.isAlive = heroStats.isAlive;
    }
}
