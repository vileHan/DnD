using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class FightUIManager : MonoBehaviour
{
    public static FightUIManager Instance;
    
    public GameObject ChooseActionPanel, LostPanel, WonPanel;
    [SerializeField] private Button attackButton, healButton, useItemButton, Skill_2Button;

    public UnitStats unitToActStats;
    
//    public ActionChosen ActionChosen;
    public static event Action<ActionState> OnActionStateChanged;
    public bool heroAttacking;
    

    public GameObject damageNumberPrefab, healingNumberPrefab;
    public Canvas worldCanvas;

    void Awake()
    {
        Instance = this;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state)
    {
        ChooseActionPanel.SetActive(state == GameState.ChooseAction);
        if (state == GameState.ChooseAction)        
        {
            unitToActStats = UnitManager.Instance.unitToAct.GetComponent<UnitStats>();
        }
        WonPanel.SetActive(state == GameState.FightWon);
        LostPanel.SetActive(state == GameState.FightLost);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowDamageNumber(Vector3 unit, float damageAmount)
    {
        // Instantiate a damage number prefab
        GameObject damageNumberObject = Instantiate(damageNumberPrefab, worldCanvas.transform);

        // Set the text to display the damage amount
        DamageNumber damageNumber = damageNumberObject.GetComponent<DamageNumber>();
        damageNumber.SetDamageText(damageAmount);

        // Position the damage number on the unit
        Vector3 worldPosition = unit; // Adjust position above the unit (unit.transform.position+Vector.up) to show number above unit
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        damageNumberObject.transform.position = screenPosition;

        // Optional: Add animations, e.g., fading out or moving upward
        damageNumber.Animate();
    }
    public void ShowHealingNumber(Vector3 unit, float damageAmount)
    {
        // Instantiate a damage number prefab
        GameObject healingNumberObject = Instantiate(healingNumberPrefab, worldCanvas.transform);

        // Set the text to display the damage amount
        DamageNumber damageNumber = healingNumberObject.GetComponent<DamageNumber>();
        damageNumber.SetDamageText(damageAmount);

        // Position the damage number on the unit
        Vector3 worldPosition = unit; // Adjust position above the unit (unit.transform.position+Vector.up) to show number above unit
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        healingNumberObject.transform.position = screenPosition;

        // Optional: Add animations, e.g., fading out or moving upward
        damageNumber.Animate();
    }

    public void UpdateAction(ActionState newAction)
    {
        OnActionStateChanged?.Invoke(newAction);

        switch(newAction)
        {
            case ActionState.Attack:
                HandleAttack();
                break;
            case ActionState.Heal:
                HandleHeal();
                break;
            case ActionState.Skill_2:
                HandleSkill_2();
                break;
            case ActionState.UseItem:
                HandleUseItem();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newAction), newAction, null);
        }
    }

    public void AttackPressed()
    {
        UpdateAction(ActionState.Attack);
    }
    public void HandleAttack()
    {        
        ChooseActionPanel.SetActive(false);
    }

    public void HealPressed()
    {
        UpdateAction(ActionState.Heal);
    }
    public void HandleHeal()
    {
        if (unitToActStats.currentSpellSlots > 0)
        {
            unitToActStats.currentSpellSlots--;
            unitToActStats.Heal();
            ChooseActionPanel.SetActive(false);
            FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }

    public void Skill_2Pressed()
    {
        UpdateAction(ActionState.Skill_2);
    }
    public void HandleSkill_2()
    {

    }

    public void UseItemPressed()
    {
        UpdateAction(ActionState.UseItem);
    }
    public void HandleUseItem()
    {
        Debug.Log("Choose Item!");
        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
    

    
    public void HeroEndTurn()
    {
        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
}
    public enum ActionState
    {
        Attack,
        Heal,
        Skill_2,
        UseItem
    }
    
