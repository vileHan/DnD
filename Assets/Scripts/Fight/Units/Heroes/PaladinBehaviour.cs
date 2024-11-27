using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    void Awake()
    {
        SetStats();
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.FightWon)
        {
            SaveStats();
        }
        if (state == GameState.FightLost)
        {
            //pokecenter
        }
    }

    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitStats.isTurn)
        {
            outline.enabled = true;
            if (Input.GetMouseButtonDown(0) && FightUIManager.Instance.heroAttacking)
            {
                HandleAttack();
            }
        }
        else
        {
            outline.enabled = false;
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
                AttackEnemy(targetEnemy);
            }
            else
            {
                Debug.Log("no enemy selected");
            }
        }
    }
    void AttackEnemy(EnemyBehaviour enemy)
    {
        Debug.Log(enemy.name);

        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(unitStats.damage);
        
        EndTurn();
    }
    void EndTurn()
    {
        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
        FightUIManager.Instance.heroAttacking = false;
    }

    void SetStats() // make this a list or something
    {
        unitStats.maxHealth = PaladinStats.Instance.maxHealth;
        unitStats.currentHealth = PaladinStats.Instance.currentHealth;
        unitStats.damage = PaladinStats.Instance.damage;
        unitStats.maxSpellSlots = PaladinStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = PaladinStats.Instance.currentSpellSlots;
        unitStats.healModifier = PaladinStats.Instance.healModifier;
        unitStats.isAlive = PaladinStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        PaladinStats.Instance.currentHealth = unitStats.currentHealth;   
        PaladinStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        PaladinStats.Instance.isAlive = unitStats.isAlive;
    }
}
