using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitStats: TargetableUnit
{
    [SerializeField] private Outline outline;

    [SerializeField]private HealthbarHandler healthbarHandler;
    public BaseEnemyBehaviour baseEnemyBehaviour;

    public int spellCost;
    public bool ableToAttack;

    public int minGoldReward;
    public int maxGoldReward;
    public int expReward;

    void Start()
    {        
        outline = gameObject.GetComponent<Outline>();
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth); // maybe put healthbar in enemybehaviour
        initiative = UnityEngine.Random.Range(1, 21);
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {        
        
    }

    private void OnMouseEnter() 
    {
        MouseEnterUnit();
    }
    private void OnMouseExit()
    {
        MouseExitUnit();
    }

    public override void TakeDamage(float damage)
    {
        float actualDamage = damage - armor;
        if (actualDamage < 0)
        {
            actualDamage = 0;
        }
        else if (actualDamage < 40)
        {
            SmallHitFeedback?.PlayFeedbacks();
        }
        else if (actualDamage < 80)
        {
            MediumHitFeedback?.PlayFeedbacks();
        }
        else 
        {
            LargeHitFeedback?.PlayFeedbacks();
        }
        currentHealth -= actualDamage;
        
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth);
        FightUIManager.Instance.ShowDamageNumber(damageNumber.position, actualDamage);
        if (currentHealth <= 0)
        {
            Die();
        }
        else 
        {
            baseEnemyBehaviour.GotHitAnimation();
        }
    }
    public override void Die()
    {
        baseEnemyBehaviour.DeathAnimation();
        DisableHealthbar();
        isAlive = false;
        TurnOrderUIHandler.Instance.DeleteTurnImage();
        UnitManager.Instance.RemoveUnit(gameObject);
        UnitManager.Instance.RemoveUnitDictionary(gameObject);

        FightManager.Instance.fightGoldReward += UnityEngine.Random.Range(minGoldReward, maxGoldReward);
        FightManager.Instance.fightExpReward += expReward;

        int randomRoll = UnityEngine.Random.Range(0,10); // later item assigned to enemy that can drop or something to that extend
            if (randomRoll < 1)
            {
                Debug.Log("Rare Loot!");
            }
    }
    public override void Heal(float healModifier)
    {
        baseEnemyBehaviour.HealAnimation();
    }

    public override void MouseEnterUnit()
    {
        SetStatsToDisplay();
        FightUIManager.Instance.EnableUnitStatsDisplay();
        outline.enabled = true;
    }
    public override void MouseExitUnit()
    {
        FightUIManager.Instance.DisableUnitStatsDisplay();
        outline.enabled = false;

    }
    public override void SetStatsToDisplay()
    {
        FightUIManager.Instance.unitHealthText.text = currentHealth+ "/" + maxHealth;
        FightUIManager.Instance.testStatText_1.text = "???";
        FightUIManager.Instance.testStatText_2.text = "??";
    }
}
