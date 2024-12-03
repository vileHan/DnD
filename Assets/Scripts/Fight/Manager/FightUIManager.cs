using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class FightUIManager : MonoBehaviour
{
    public static FightUIManager Instance;
    
    public GameObject LostPanel, WonPanel, UnitStatsPanel;
    public GameObject[] heroActionPanels;
    [HideInInspector] public GameObject chooseActionPanel;
    //[SerializeField] private Button primaryAttackButton, healButton, useItemButton, Spell_2Button;

    public TMP_Text unitHealthText, testText_1, testText_2, roundCounterText;

    public HeroStats heroToAct;
    
//    public ActionChosen ActionChosen;
    public static event Action<ActionState> OnActionStateChanged;
    public bool heroAttacking;
    

    public GameObject damageNumberPrefab, healingNumberPrefab;
    public Canvas worldCanvas;

    public int roundCounter = 1;
    void Awake()
    {
        Instance = this;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
        roundCounterText.text = roundCounter.ToString();
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state)
    { 
        if (state == GameState.ChooseAction)        
        {
            heroToAct = FightManager.Instance.unitToAct.GetComponent<HeroStats>();
            chooseActionPanel = heroActionPanels[heroToAct.panelIndex];
            chooseActionPanel.SetActive(state == GameState.ChooseAction);
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
            case ActionState.SecondaryAttack:
                HandleSecondaryAttack();
                break;
            case ActionState.Spell_1:
                HandleSpell_1();
                break;
            case ActionState.Spell_2:
                HandleSpell_2();
                break;
            case ActionState.Spell_3:
                HandleSpell_3();
                break;
            case ActionState.Spell_4:
                HandleSpell_4();
                break;
            case ActionState.Spell_5:
                HandleSpell_5();
                break;
            case ActionState.Spell_6:
                HandleSpell_6();
                break;
            case ActionState.Spell_7:
                HandleSpell_7();
                break;
            case ActionState.Spell_8:
                HandleSpell_8();
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
        chooseActionPanel.SetActive(false);
    }
    public void SecondaryAttackPressed()
    {
        UpdateAction(ActionState.SecondaryAttack);
    }
    public void HandleSecondaryAttack()
    {        
        chooseActionPanel.SetActive(false);
    }

    public void Spell_1Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_1);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_1()
    {
        chooseActionPanel.SetActive(false);         
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
        chooseActionPanel.SetActive(false);
    }
    public void Spell_3Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_3);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_3()
    {
        chooseActionPanel.SetActive(false);
    }
    public void Spell_4Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_4);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_4()
    {
        chooseActionPanel.SetActive(false);
    }
    public void Spell_5Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_5);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_5()
    {
        chooseActionPanel.SetActive(false);
    }
    public void Spell_6Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_6);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_6()
    {
        chooseActionPanel.SetActive(false);
    }
    public void Spell_7Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_7);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_7()
    {
        chooseActionPanel.SetActive(false);
    }
    public void Spell_8Pressed()
    {
        if (HasSpellslots(heroToAct.SpellCostCalculator()))
        {
            UpdateAction(ActionState.Spell_8);
        }
        else
        {
            Debug.Log("Out of Spellslots!");
        }
    }
    public void HandleSpell_8()
    {
        chooseActionPanel.SetActive(false);
    }

    public void UseItemPressed()
    {
        UpdateAction(ActionState.UseItem);
    }
    public void HandleUseItem()
    {
        Debug.Log("Choose Item!");
        chooseActionPanel.SetActive(false);
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

    public void EnableUnitStatsDisplay()
    {
        UnitStatsPanel.SetActive(true);
    }
    public void DisableUnitStatsDisplay()
    {
        UnitStatsPanel.SetActive(false);
    }

    public void DisplaySkill()
    {
        Debug.Log("hover over button");
    }

    public void DisplayTurnOrder()
    {
        
    }
    
    public void UpdateRoundCounter()
    {
        roundCounter++;
        roundCounterText.text = roundCounter.ToString();
    }
}
    public enum ActionState
    {
        PrimaryAttack,
        SecondaryAttack,
        Spell_1,
        Spell_2,
        Spell_3,
        Spell_4,
        Spell_5,
        Spell_6,
        Spell_7,
        Spell_8,
        UseItem
    }
    
