using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroStats: TargetableUnit
{

    [SerializeField]private HealthbarHandler healthbarHandler;
    [SerializeField]private BaseHeroBehaviour behaviour;

    public KnightAnimationScript knightAnimationScript;
    [SerializeField] private Outline outline;

    public Transform damageNumber;

    public int spellCost; 
    public bool ableToAttack;

    void Awake()
    {
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
        FightUIManager.OnActionStateChanged += FightUIManagerOnActionStateChanged;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
        FightUIManager.OnActionStateChanged -= FightUIManagerOnActionStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state) //put able to attack somewhere here
    {
        if (state == GameState.FightLost)
        {
            //pokecenter
        }
        if (isTurn && state == GameState.SelectUnitTurn)
        {
            behaviour.ResetAttackIndex();
        }
        if (isTurn && state == GameState.ExecuteHeroTurn)
        {
            FightManager.Instance.UpdateGameState(GameState.ChooseAction);            
        }
    }

    private void FightUIManagerOnActionStateChanged(ActionState state)
    {
        if (isTurn && state == ActionState.NoAttack)
        {
            behaviour.SetAttackIndex(0);
        }
        if (isTurn && state == ActionState.PrimaryAttack)
        {
            behaviour.SetAttackIndex(1);
        }
        if (isTurn && state == ActionState.SecondaryAttack)
        {
            behaviour.SetAttackIndex(2);
        }
        if (isTurn && state == ActionState.Spell_1)
        {
            behaviour.SetAttackIndex(3);
        }
        if (isTurn && state == ActionState.Spell_2)
        {
            behaviour.SetAttackIndex(4);
        }
        if (isTurn && state == ActionState.Spell_3)
        {
            behaviour.SetAttackIndex(5);
        }
        if (isTurn && state == ActionState.Spell_4)
        {
            behaviour.SetAttackIndex(6);
        }
        if (isTurn && state == ActionState.Spell_5)
        {
            behaviour.SetAttackIndex(7);
        }
        if (isTurn && state == ActionState.Spell_6)
        {
            behaviour.SetAttackIndex(8);
        }
        if (isTurn && state == ActionState.Spell_7)
        {
            behaviour.SetAttackIndex(9);
        }
        if (isTurn && state == ActionState.Spell_8)
        {
            behaviour.SetAttackIndex(10);
        }
    }

    void Start()
    {     
        outline = gameObject.GetComponent<Outline>();
        healthbarHandler.SetHealthbar(maxHealth, currentHealth);
        initiative = UnityEngine.Random.Range(1, 21);
    }

    // Update is called once per frame
    void Update()
    {        
        if (isTurn && !behaviour.isInAnimation)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleAttack();
            }
        }
    }

    private void OnMouseEnter() 
    {
        MouseEnterUnit();
    }
    private void OnMouseExit()
    {
        MouseExitUnit();
    }

    public void HandleAttack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast hits a target
            TargetableUnit target = hit.collider.GetComponent<TargetableUnit>();
            if (target != null)
            {
                switch(behaviour.heroAttackingIndex)
                {
                    case 0:
                        Debug.Log("no action selected");
                        break;
                    case 1:
                        behaviour.PrimaryAttack(target);
                        break;
                    case 2:
                        behaviour.SecondaryAttack(target);
                        break;
                    case 3:
                        behaviour.Spell_1Against(target);
                        break;
                    case 4:
                        behaviour.Spell_2Against(target);
                        break;
                    case 5:
                        behaviour.Spell_3Against(target);
                        break;
                    case 6:
                        behaviour.Spell_4Against(target);
                        break;
                    case 7:
                        behaviour.Spell_5Against(target);
                        break;
                    case 8:
                        behaviour.Spell_6Against(target);
                        break;
                    case 9:
                        behaviour.Spell_7Against(target);
                        break;
                    case 10:
                        behaviour.Spell_8Against(target);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(behaviour.heroAttackingIndex), behaviour.heroAttackingIndex, null);
                }
            }
            else
            {
                //Debug.Log("no enemy selected");
            }            
        }
    }

    public override void TakeDamage(float damage)
    {
        float actualDamage = damage - armor;
        if (actualDamage < 0)
        {
            actualDamage = 0;
        }
        else if (actualDamage < 20)
        {
            Debug.Log("smalldamage");
            SmallHitFeedback?.PlayFeedbacks();
        }
        else if (actualDamage < 40)
        {
            Debug.Log("meddamage");
            MediumHitFeedback?.PlayFeedbacks();
        }
        else 
        {
            Debug.Log("largedamage");
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
            knightAnimationScript.GotHitAnimation();
        }
        
    }
    public override void Die()
    {
        knightAnimationScript.DeathAnimation();
        DisableHealthbar();
        isAlive = false;
        TurnOrderUIHandler.Instance.DeleteTurnImage();
        UnitManager.Instance.RemoveUnit(gameObject);
        UnitManager.Instance.RemoveUnitDictionary(gameObject);
        //gameObject.SetActive(false);
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

    public override int SpellCostCalculator()
    {
        // maybe different calculation for a later stage gl future me :)
        spellCost = 1;
        return spellCost;
    }

    public override void MouseEnterUnit()
    {
        SetStatsToDisplay();
        FightUIManager.Instance.EnableUnitStatsDisplay();
    }
    public override void MouseExitUnit()
    {
        FightUIManager.Instance.DisableUnitStatsDisplay();
    }
    public override void SetStatsToDisplay()
    {
        FightUIManager.Instance.unitHealthText.text = currentHealth+ "/" + maxHealth;
        FightUIManager.Instance.testText_1.text = "???";
        FightUIManager.Instance.testText_2.text = "??";
    }
}