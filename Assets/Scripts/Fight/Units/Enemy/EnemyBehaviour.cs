using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : BaseHeroBehaviour
{
    public TargetableUnit unitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    public DemonAnimationScript demonAnimationScript;

    private Color baseColor = new Color(1f, 1f, 1f, 1f);
    
    void Start()
    {
        unitStats.currentHealth = unitStats.maxHealth;
        unitStats.currentSpellSlots = unitStats.maxSpellSlots;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public IEnumerator Action()
    {
        yield return new WaitForSeconds(0.5f);

        DecideAction();

        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }

    public void Attack()
    {
        GameObject targetedHero = UnitManager.Instance.heroesAlive[Random.Range(0, UnitManager.Instance.heroesAlive.Count)]; // random right now -> later maybe look for target with lowest health
        TargetableUnit targetHeroStats = targetedHero.GetComponent<TargetableUnit>();  
        targetHeroStats.TakeDamage(unitStats.damage);
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

    public void DecideAction() // later stages make th switch case for differnt actions? or make enemy look if hp is low etc.
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
