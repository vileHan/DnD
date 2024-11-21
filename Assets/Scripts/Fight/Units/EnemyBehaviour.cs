using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField] private UnitStats unitStats;
    private UnitStats attackingUnitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    private FightUIManager fightUIManager;
    private HeroBehaviour heroBehaviour;

    private Color baseColor = new Color(1f, 1f, 1f, 1f);
    public bool mouseOverEnemy;
    
    void Start()
    {
        fightUIManager = GameObject.FindGameObjectWithTag("FightUIManager").GetComponent<FightUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseLogic();        
    }

    private void OnMouseEnter() 
    {
        mouseOverEnemy = true;
    }
    private void OnMouseExit()
    {
        mouseOverEnemy = false;
    }

    private void MouseLogic()
    {
        if(mouseOverEnemy && fightUIManager.heroAttacking)
        {
            //Renderer.material.color = new Color(1f, 0f, 0f, 1f);
            if (Input.GetMouseButtonDown(0))
            {
                LoseHealth();
                EndTurn();
                if (unitStats.currentHealth <= 0)
                {
                    unitStats.Die();
                }
            }
        }
    }

    public void Attack()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Player");
        
        GameObject targetedHero = heroes[Random.Range(0, heroes.Length)]; // random right now -> later maybe look for target with lowest health
        UnitStats targetUnitStats = targetedHero.GetComponent<UnitStats>();  
        targetUnitStats.TakeDamage(unitStats.damage);
        //Debug.Log(UnitManager.Instance.unitToAct.name+" dealt "+ unitStats.damage + " damage to " + targetedHero.name);
        unitStats.isTurn = false;

        GameManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
    private void LoseHealth()
    {
        attackingUnitStats = UnitManager.Instance.unitToAct.GetComponent<UnitStats>();
        unitStats.TakeDamage(attackingUnitStats.damage);
    }
    private void EndTurn()
    {
        GameManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
        fightUIManager.heroAttacking = false;
    }

}
