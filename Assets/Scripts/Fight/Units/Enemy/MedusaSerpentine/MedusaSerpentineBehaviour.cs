using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaSerpentineBehaviour : BaseEnemyBehaviour
{
    public TargetableUnit unitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    public MedusaSerpentineAnimationScript medusaSerpentineAnimationScript;
    
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
        int chance = Random.Range(1, 4);
        if (chance == 1)
        {
            medusaSerpentineAnimationScript.Attack1Animation();

        }
        if (chance == 2)
        {
            medusaSerpentineAnimationScript.Attack2Animation();
        }
        if (chance == 3)
        {
            medusaSerpentineAnimationScript.Attack3Animation();
        }
    }

    public override void DecideAction() // later stages make th switch case for differnt actions? or make enemy look if hp is low etc.
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

    public override void GotHitAnimation()
    {
        medusaSerpentineAnimationScript.GotHitAnimation();
    }
    public override void DeathAnimation()
    {
        medusaSerpentineAnimationScript.DeathAnimation();
    }
    public override void HealAnimation()
    {
        medusaSerpentineAnimationScript.TauntAnimation();
    }
}
