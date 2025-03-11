using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAnimationEvents : MonoBehaviour
{
    private TargetableUnit targetableUnit;
    [SerializeField]private HealthbarHandler healthbarHandler;

    private Vector3 originalPosition;

    void Awake()
    {
        targetableUnit = GetComponentInParent<TargetableUnit>();
        originalPosition = transform.position;
    }

    void Update()
    {
        transform.position = originalPosition;
    }

    public void AttackAnimationEvent()
    {
        GameObject targetedHero = UnitManager.Instance.heroesAlive[Random.Range(0, UnitManager.Instance.heroesAlive.Count)]; // random right now -> later maybe look for target with lowest health
        TargetableUnit targetHeroStats = targetedHero.GetComponent<TargetableUnit>();  
        targetHeroStats.TakeDamage(targetableUnit.damage);
    }
    public void HealAnimationEvent()
    {
        float healthHealed = targetableUnit.currentHealth + targetableUnit.healModifier;
        if (healthHealed > targetableUnit.maxHealth)
        {
            healthHealed -= targetableUnit.maxHealth;
            healthHealed = targetableUnit.healModifier - healthHealed;
        }
        else 
        {
            healthHealed = targetableUnit.healModifier;
        }
        targetableUnit.currentHealth += targetableUnit.healModifier;
        if (targetableUnit.currentHealth > targetableUnit.maxHealth)
        {
            targetableUnit.currentHealth = targetableUnit.maxHealth;
        }   
        healthbarHandler.UpdateHealthbar(targetableUnit.maxHealth, targetableUnit.currentHealth);      
        FightUIManager.Instance.ShowHealingNumber(targetableUnit.damageNumber.position, healthHealed);
    }
    public void AnimationFinished()
    {   
        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
}
