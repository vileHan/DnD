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
    [SerializeField] private Button primaryAttackButton, healButton, useItemButton, Spell_2Button;

    public HeroStats heroToAct;
    
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
            heroToAct = FightManager.Instance.unitToAct.GetComponent<HeroStats>();
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
            case ActionState.PrimaryAttack:
                HandlePrimaryAttack();
                break;
            case ActionState.Heal:
                HandleHeal();
                break;
            case ActionState.Spell_2:
                HandleSpell_2();
                break;
            case ActionState.UseItem:
                HandleUseItem();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newAction), newAction, null);
        }
    }

    public void PrimaryAttackPressed()
    {
        UpdateAction(ActionState.PrimaryAttack);
    }
    public void HandlePrimaryAttack()
    {        
        ChooseActionPanel.SetActive(false);
    }

    public void HealPressed()
    {
        if (heroToAct.currentSpellSlots > 0)
        {
            heroToAct.currentSpellSlots -= 1;
            UpdateAction(ActionState.Heal);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleHeal()
    {
        heroToAct.Heal();
        ChooseActionPanel.SetActive(false);
        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);        
    }

    public void Spell_2Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_2);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_2()
    {
        ChooseActionPanel.SetActive(false);
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

    public bool HasSpellslots(int spellCost)
    {
        if (heroToAct.currentSpellSlots >= spellCost)
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }
}
    public enum ActionState
    {
        PrimaryAttack,
        Heal,
        Spell_2,
        UseItem
    }
    
