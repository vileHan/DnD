using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{

    [SerializeField]private HealthbarHandler healthbarHandler;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public int initiative;
    public int spellSlots;
    public bool isTurn; 
    public bool ableToAttack;

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
                HeroBehaviour heroBehaviour = gameObject.GetComponent<HeroBehaviour>();
                heroBehaviour.ChooseAction();
            }
            else if (gameObject.tag == "Enemy")
            {
                EnemyBehaviour enemyBehaviour = gameObject.GetComponent<EnemyBehaviour>();
                StartCoroutine(enemyBehaviour.Attack());
            }
            
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthbarHandler.UpdateHealthbar(maxHealth, currentHealth);
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

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        UnitManager.Instance.RemoveUnitDictionary(gameObject);
        Destroy(gameObject);
    }

        
}
