using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonkBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    void Awake()
    {
        SetStats();
        FightUIManager.OnActionStateChanged += FightUIManagerOnActionStateChanged;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightUIManager.OnActionStateChanged -= FightUIManagerOnActionStateChanged;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
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
    private void FightUIManagerOnActionStateChanged(ActionState state)
    {
        if (state == ActionState.Attack)
        {
            FightManager.Instance.heroAttackingIndex = 1;
        }
        if (state == ActionState.Skill_2)
        {
            FightManager.Instance.heroAttackingIndex = 4;
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
            if (Input.GetMouseButtonDown(0))
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
                switch(FightManager.Instance.heroAttackingIndex)
                {
                    case 0:
                        Debug.Log("no action selected");
                        break;
                    case 1:
                        Debug.Log("attack1 " + FightManager.Instance.heroAttackingIndex);
                        AttackEnemy(targetEnemy);
                        break;
                    case 2:
                        Debug.Log("attack2");
                        break;
                    case 3:
                        Debug.Log("skill1");
                        break;
                    case 4:
                        Debug.Log("skill2");
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
    void AttackEnemy(EnemyBehaviour enemy)
    {
        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(unitStats.damage);
        
        FightUIManager.Instance.HeroEndTurn();
    }

    void SetStats() // make this a list or something
    {
        unitStats.maxHealth = MonkStats.Instance.maxHealth;
        unitStats.currentHealth = MonkStats.Instance.currentHealth;
        unitStats.damage = MonkStats.Instance.damage;
        unitStats.maxSpellSlots = MonkStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = MonkStats.Instance.currentSpellSlots;
        unitStats.healModifier = MonkStats.Instance.healModifier;
        unitStats.isAlive = MonkStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        MonkStats.Instance.currentHealth = unitStats.currentHealth;   
        MonkStats.Instance.currentSpellSlots = unitStats.currentSpellSlots;  
        MonkStats.Instance.isAlive = unitStats.isAlive;
    }
}
