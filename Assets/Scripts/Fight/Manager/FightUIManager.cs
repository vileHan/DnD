using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FightUIManager : MonoBehaviour
{
    public GameObject ChooseActionPanel;
    //private EnemyBehaviour enemyBehaviour;
    private HeroBehaviour heroBehaviour;

    public bool ableToBeAttacked;
    public UnitStats attackingUnitStats;
    public float attackingUnitDamage;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        ChooseActionPanel.SetActive(state == GameState.ChooseAction);
        if (state == GameState.ChooseAction)
        {
            GetAttackValueFromAttackingUnit();
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {        
        attackingUnitStats.ableToAttack = true;  
    }
    public void GetAttackValueFromAttackingUnit()
    {
        GameObject attackingUnit = UnitManager.Instance.unitToAct;
        attackingUnitStats = attackingUnit.GetComponent<UnitStats>();  
        attackingUnitDamage = attackingUnitStats.damage;
    }
}
