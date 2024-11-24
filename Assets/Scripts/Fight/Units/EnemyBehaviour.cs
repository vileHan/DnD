using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField] private UnitStats unitStats;
    [SerializeField] private Outline outline;
    private UnitStats attackingUnitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    private HeroBehaviour heroBehaviour;

    private Color baseColor = new Color(1f, 1f, 1f, 1f);
    public bool mouseOverEnemy;
    
    void Start()
    {
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseLogic();        
    }

    private void OnMouseEnter() 
    {
        mouseOverEnemy = true;
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        mouseOverEnemy = false;
        outline.enabled = false;
    }

    private void MouseLogic()
    {
        if(mouseOverEnemy && FightUIManager.Instance.heroAttacking)
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

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject targetedHero = UnitManager.Instance.heroesAlive[Random.Range(0, UnitManager.Instance.heroesAlive.Count)]; // random right now -> later maybe look for target with lowest health
        UnitStats targetUnitStats = targetedHero.GetComponent<UnitStats>();  
        targetUnitStats.TakeDamage(unitStats.damage);

        GameManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
    private void LoseHealth()
    {
        attackingUnitStats = UnitManager.Instance.unitToAct.GetComponent<UnitStats>();
        unitStats.TakeDamage(attackingUnitStats.damage);
        FightUIManager.Instance.ShowDamageNumber(unitStats.damageNumber.position, attackingUnitStats.damage);
    }
    private void EndTurn()
    {
        GameManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
        FightUIManager.Instance.heroAttacking = false;
    }

}
