using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitStats: TargetableUnit
{
    [SerializeField] private Outline outline;
    [SerializeField] public GameObject characterImage;

    [SerializeField]private HealthbarHandler healthbarHandler;

    public Transform damageNumber;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public int maxSpellSlots;
    public int currentSpellSlots;
    public int spellCost;
    public bool ableToAttack;
    public float healModifier;

    public bool isTurn; 
    public bool isAlive;
    public int initiative;

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
        currentHealth -= damage;
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth);
        FightUIManager.Instance.ShowDamageNumber(damageNumber.position, damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        isAlive = false;
        TurnOrderUIHandler.Instance.DeleteTurnImage();
        UnitManager.Instance.RemoveUnit(gameObject);
        UnitManager.Instance.RemoveUnitDictionary(gameObject);
        gameObject.SetActive(false);
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
