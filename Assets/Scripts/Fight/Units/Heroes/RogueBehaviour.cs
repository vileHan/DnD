using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RogueBehaviour : MonoBehaviour
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
                        Skill_2AgainstEnemy(targetEnemy);
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
            Debug.Log("after attack");
        }
    }
    void AttackEnemy(EnemyBehaviour enemy)
    {
        // Deal damage to the enemy
        enemy.unitStats.TakeDamage(unitStats.damage);
        
        FightUIManager.Instance.HeroEndTurn();
    }
    void Skill_2AgainstEnemy(EnemyBehaviour enemy)
    {
        enemy.unitStats.TakeDamage((unitStats.damage*2));
    }

    void SetStats() // make this a list or something
    {
        unitStats.maxHealth = RogueStats.Instance.maxHealth;
        unitStats.currentHealth = RogueStats.Instance.currentHealth;
        unitStats.damage = RogueStats.Instance.damage;
        unitStats.maxSpellSlots = RogueStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = RogueStats.Instance.currentSpellSlots;
        unitStats.healModifier = RogueStats.Instance.healModifier;
        unitStats.isAlive = RogueStats.Instance.isAlive;
    }
    public void SaveStats() // make this a list or something
    {
        RogueStats.Instance.currentHealth = unitStats.currentHealth;   
        RogueStats.Instance.currentSpellSlots = unitStats.currentSpellSlots; 
        RogueStats.Instance.isAlive = unitStats.isAlive; 
    }
}
