using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : BaseEnemyBehaviour
{
    public TargetableUnit unitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    public DemonAnimationScript demonAnimationScript;
    
    void Awake()
    {
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
        unitStats.currentHealth = unitStats.maxHealth;
        unitStats.currentSpellSlots = unitStats.maxSpellSlots;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state) //put able to attack somewhere here
    {
        if (unitStats.isTurn && state == GameState.ExecuteHeroTurn)
        {
            StartCoroutine(Action());
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public override IEnumerator Action()
    {
        yield return new WaitForSeconds(0.5f);

        DecideAction();
    }

    public override void Attack()
    {
        int chance = Random.Range(1, 5);
        if (chance == 1)
        {
            demonAnimationScript.Attack1Animation();
        }
        if (chance == 2)
        {
            demonAnimationScript.Attack2Animation();
        }
        if (chance == 3)
        {
            demonAnimationScript.Attack3Animation();
        }
        if (chance == 4)
        {
            demonAnimationScript.Attack4Animation();
        }
    }

    public override void DecideAction() // later stages make th switch case for differnt actions? or make enemy look if hp is low etc.
    {
        if (unitStats.currentHealth < unitStats.maxHealth/2)
        {
            int actionIndex = Random.Range(0,3);
            if (actionIndex == 0)
            {
                unitStats.Heal(unitStats.healModifier);
            }
            else
            {
                Attack();
            }
        }
        else if (unitStats.currentHealth == unitStats.maxHealth)
        {
            Attack();
        }
        else 
        {
            int actionIndex = Random.Range(0,6);
            if (actionIndex == 0)
            {
                unitStats.Heal(unitStats.healModifier);
            }
            else
            {
                Attack();
            }
        }
    }

    public override void GotHitAnimation()
    {
        demonAnimationScript.GotHitAnimation();
    }
    public override void DeathAnimation()
    {
        demonAnimationScript.DeathAnimation();
    }
    public override void HealAnimation()
    {
        demonAnimationScript.TauntAnimation();
    }
}
