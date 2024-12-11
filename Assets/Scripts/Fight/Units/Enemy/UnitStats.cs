using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitStats: TargetableUnit
{
    [SerializeField] private Outline outline;

    [SerializeField]private HealthbarHandler healthbarHandler;
    public DemonAnimationScript demonAnimationScript;

    public Transform damageNumber;

    // public float maxHealth;
    // public float currentHealth;
    // public float damage;
    // public float armor;
    // public int maxSpellSlots;
    // public int currentSpellSlots;
    public int spellCost;
    public bool ableToAttack;
    // public float healModifier;

    // public bool isTurn; 
    // public bool isAlive;
    // public int initiative;

    void Awake()
    {
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state) //put able to attack somewhere here
    {
        if (isTurn && state == GameState.ExecuteHeroTurn)
        {
            EnemyBehaviour enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
            StartCoroutine(enemyBehaviour.Action());
        }
    }

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
        currentHealth -= actualDamage;
        
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth);
        FightUIManager.Instance.ShowDamageNumber(damageNumber.position, actualDamage);
        if (currentHealth <= 0)
        {
            Die();
        }
        else 
        {
            demonAnimationScript.GotHitAnimation();
        }
    }
    public override void Die()
    {
        demonAnimationScript.DeathAnimation();
        DisableHealthbar();
        isAlive = false;
        TurnOrderUIHandler.Instance.DeleteTurnImage();
        UnitManager.Instance.RemoveUnit(gameObject);
        UnitManager.Instance.RemoveUnitDictionary(gameObject);
    }
    public override void Heal(float healModifier)
    {
        float healthHealed = currentHealth + healModifier;
        if (healthHealed > maxHealth)
        {
            healthHealed -= maxHealth;
            healthHealed = healModifier - healthHealed;
        }
        else 
        {
            healthHealed = healModifier;
        }
        currentHealth += healModifier;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        demonAnimationScript.TauntAnimation();
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth);      
        FightUIManager.Instance.ShowHealingNumber(damageNumber.position, healthHealed);
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
        FightUIManager.Instance.testText_1.text = "???";
        FightUIManager.Instance.testText_2.text = "??";
    }
}
