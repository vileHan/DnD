using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkBehaviour : BaseHeroBehaviour
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
