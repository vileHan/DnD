using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitStats : MonoBehaviour
{

    [SerializeField]private HealthbarHandler healthbarHandler;
    [SerializeField]private BaseHeroBehaviour behaviour;
    public Transform damageNumber;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public int maxSpellSlots;
    public int currentSpellSlots;
    public bool isTurn; 
    public bool ableToAttack;
    public float healModifier;
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

    void Start()
    {        
        healthbarHandler.SetHealthbar(maxHealth, currentHealth);
        initiative = UnityEngine.Random.Range(1, 21);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleAttack();
            }
        }
    }

    void HandleAttack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the raycast hits an enemy
            EnemyBehaviour targetEnemy = hit.collider.GetComponent<EnemyBehaviour>();
            if (targetEnemy != null)
            {
                switch(FightManager.Instance.heroAttackingIndex)
                {
                    case 0:
                        Debug.Log("no action selected");
                        break;
                    case 1:
                        Debug.Log("attack1 " + FightManager.Instance.heroAttackingIndex);
                        behaviour.PrimaryAttackEnemy(targetEnemy);
                        break;
                    case 2:
                        Debug.Log("attack2");
                        break;
                    case 3:
                        Debug.Log("skill1");
                        break;
                    case 4:
                        behaviour.Skill_2AgainstEnemy(targetEnemy);
                        Debug.Log("skill2");
                        break;
                    case 5:
                        Debug.Log("skill3");
                        break;
                    case 6:
                        Debug.Log("skill4");
                        break;
                    case 7:
                        Debug.Log("skill5");
                        break;
                    case 8:
                        Debug.Log("skill6");
                        break;
                    case 9:
                        Debug.Log("skill7");
                        break;
                    case 10:
                        Debug.Log("skill8");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(FightManager.Instance.heroAttackingIndex), FightManager.Instance.heroAttackingIndex, null);
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
}
