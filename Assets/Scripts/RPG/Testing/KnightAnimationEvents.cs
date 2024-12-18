using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class KnightAnimationEvents : MonoBehaviour
{
    private BaseHeroBehaviour baseHeroBehaviour;
    private TargetableUnit targetableUnit;
    [SerializeField]private HealthbarHandler healthbarHandler;
    public GameObject[] effects;
    public GameObject effectsObject;
    public MMFeedbacks screenFlash;

    void Awake()
    {
        baseHeroBehaviour = GetComponentInParent<BaseHeroBehaviour>();
        targetableUnit = GetComponentInParent<TargetableUnit>();
    }
    public void AttackAnimationEvent()
    {
        baseHeroBehaviour.target.TakeDamage(targetableUnit.damage);
    }
    public void StabAnimationEvent()
    {
        baseHeroBehaviour.target.TakeDamage((targetableUnit.damage)*1.5f);
    }
    public void AoEAttackAnimationEvent()
    {
        int initialEnemyCount = UnitManager.Instance.enemiesAlive.Count;
        for (int i = 0; i < initialEnemyCount; i++)
        {
            if (i >= UnitManager.Instance.enemiesAlive.Count)
            {
                break;
            }
            TargetableUnit targetStats = UnitManager.Instance.enemiesAlive[i].GetComponent<TargetableUnit>();

            targetStats.TakeDamage((targetableUnit.damage/2));            
        }
        GameObject effect = Instantiate(effects[2], new Vector3(-89f, 0f, -97.5f), Quaternion.identity);
        Destroy(effect, 1.5f);
    }
    public void HealAnimationEvent()
    {
        GameObject effect = Instantiate(effects[0], effectsObject.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

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
    public void GetHealAnimationEvent()
    {
        GameObject effect = Instantiate(effects[0], effectsObject.transform.position, Quaternion.identity);
        Destroy(effect, 5f);

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
    public void ArmorAnimationEvent()
    {
        GameObject effect = Instantiate(effects[1], effectsObject.transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
    public void AnimationFlashEvent()
    {
        screenFlash?.PlayFeedbacks();
    }
    public void AnimationStarted()
    {
        baseHeroBehaviour.isInAnimation = true;
    }
    public void AnimationFinished()
    {
        baseHeroBehaviour.isInAnimation = false;
        FightManager.Instance.HeroEndTurn();
    }
    public void HalfAnimationFinished()
    {
        baseHeroBehaviour.isInAnimation = false;
    }    
}
