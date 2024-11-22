using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class FightUIManager : MonoBehaviour
{
    public GameObject ChooseActionPanel;
    [SerializeField] private Button attackButton, healButton, useItemButton;

    public UnitStats unitToActStats;
    
//    public ActionChosen ActionChosen;
    public static event Action<ActionState> OnActionState;
    public bool heroAttacking;

    public GameObject damageNumberPrefab;
    public Canvas worldCanvas;

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
            unitToActStats = UnitManager.Instance.unitToAct.GetComponent<UnitStats>();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HandleAttack()
    {        
        heroAttacking = true; 
        ChooseActionPanel.SetActive(false);
    }
    public void AttackPressed()
    {
        UpdateAction(ActionState.Attack);
    }
    public void HandleHeal()
    {
        if (unitToActStats.spellSlots > 0)
        {
            unitToActStats.Heal();
            ChooseActionPanel.SetActive(false);
            GameManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HealPressed()
    {
        UpdateAction(ActionState.Heal);
    }
    public void HandleUseItem()
    {
        Debug.Log("Choose Item!");
        GameManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
    public void UseItemPressed()
    {
        UpdateAction(ActionState.UseItem);
    }

    public void UpdateAction(ActionState newAction)
    {
        OnActionState?.Invoke(newAction);

        switch(newAction)
        {
            case ActionState.Attack:
                HandleAttack();
                break;
            case ActionState.Heal:
                HandleHeal();
                break;
            case ActionState.UseItem:
                HandleUseItem();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newAction), newAction, null);
        }
    }

    public void ShowDamageNumber(GameObject unit, float damageAmount)
    {
        // Instantiate a damage number prefab
        GameObject damageNumberObject = Instantiate(damageNumberPrefab, worldCanvas.transform);

        // Set the text to display the damage amount
        DamageNumber damageNumber = damageNumberObject.GetComponent<DamageNumber>();
        damageNumber.SetDamageText(damageAmount);

        // Position the damage number above the unit
        Vector3 worldPosition = unit.transform.position + Vector3.up; // Adjust position above the unit
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        damageNumberObject.transform.position = screenPosition;

        // Optional: Add animations, e.g., fading out or moving upward
        damageNumber.Animate();
    }
}
    public enum ActionState
    {
        Attack,
        Heal,
        UseItem
    }
    
