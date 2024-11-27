using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{

    [SerializeField]private HealthbarHandler healthbarHandler;
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
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state) //put able to attack somewhere here
    {
        if (isTurn && state == GameState.ExecuteUnitTurn)
        {
            if (gameObject.tag == "Player")
            {
                GameManager.Instance.UpdateGameState(GameState.ChooseAction);
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
        initiative = Random.Range(1, 21);
    }

    // Update is called once per frame
    void Update()
    {
        
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
