using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitStats: MonoBehaviour
{

    [SerializeField]private HealthbarHandler healthbarHandler;
    [SerializeField]private BaseHeroBehaviour behaviour;

    [SerializeField] private Outline outline;

    public Transform damageNumber;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public int maxSpellSlots;
    public int currentSpellSlots;
    public int spellCost;
    public bool isTurn; 
    public bool ableToAttack;
    public float healModifier;
    public bool isAlive;

    public int initiative;

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
        if (isTurn && state == GameState.ExecuteUnitTurn)
        {
            if (gameObject.tag == "Player")
            {
                FightManager.Instance.UpdateGameState(GameState.ChooseAction);
            }
            else if (gameObject.tag == "Enemy")
            {
                EnemyBehaviour enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
                StartCoroutine(enemyBehaviour.Action());
            }
        }
    }

    private void FightUIManagerOnActionStateChanged(ActionState state)
    {
        if (isTurn && state == ActionState.PrimaryAttack)
        {
            behaviour.SetAttackIndex(1);
        }
        if (isTurn && state == ActionState.Spell_2)
        {
            behaviour.SetAttackIndex(4);
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
        if (isTurn && gameObject.tag == "Player")
        {
            outline.enabled = true;
            if (Input.GetMouseButtonDown(0))
            {
                HandleAttack();
            }
        }
        else if (!isTurn && gameObject.tag == "Player")
        {
            outline.enabled = false;
        }
    }

    public void HandleAttack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast hits a target
            
            EnemyBehaviour targetEnemy = hit.collider.GetComponent<EnemyBehaviour>();
            if (targetEnemy != null)
            {
                switch(behaviour.heroAttackingIndex)
                {
                    case 0:
                        Debug.Log("no action selected");
                        break;
                    case 1:
                        Debug.Log("attack1");
                        behaviour.PrimaryAttackEnemy(targetEnemy);
                        break;
                    case 2:
                        Debug.Log("attack2");
                        break;
                    case 3:
                        Debug.Log("Spell1");
                        break;
                    case 4:
                        behaviour.Spell_2AgainstEnemy(targetEnemy);
                        Debug.Log("Spell2");
                        break;
                    case 5:
                        Debug.Log("Spell3");
                        break;
                    case 6:
                        Debug.Log("Spell4");
                        break;
                    case 7:
                        Debug.Log("Spell5");
                        break;
                    case 8:
                        Debug.Log("Spell6");
                        break;
                    case 9:
                        Debug.Log("Spell7");
                        break;
                    case 10:
                        Debug.Log("Spell8");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(behaviour.heroAttackingIndex), behaviour.heroAttackingIndex, null);
                }
            }
            else
            {
                Debug.Log("no enemy selected");
            }            
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth);
        FightUIManager.Instance.ShowDamageNumber(damageNumber.position, damage);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        UnitManager.Instance.RemoveUnit(gameObject);
        UnitManager.Instance.RemoveUnitDictionary(gameObject);
        if (gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            isAlive = false;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void Heal()
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
    public void HealTest()
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

    public int SpellCostCalculator()
    {
        // maybe different calculation for a later stage gl future me :)
        spellCost = 1;
        return spellCost;
    }
}