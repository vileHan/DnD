using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MonkButtonManager : MonoBehaviour
{
    public static MonkButtonManager Instance;
    private Vector3 DescriptionPanelPosition_1 = new Vector3(1085, 330, 0);
    private Vector3 DescriptionPanelPosition_2 = new Vector3(1220, 330, 0);
    private Vector3 DescriptionPanelPosition_3 = new Vector3(1360, 330, 0);
    private Vector3 DescriptionPanelPosition_4 = new Vector3(1500, 330, 0);
    private Vector3 DescriptionPanelPosition_5 = new Vector3(1640, 330, 0);
    [SerializeField] private GameObject ActionDescriptionPanel;
    [SerializeField] private TMP_Text actionDescriptionHeaderText, actionDescriptionDescriptionText;


    public HeroStats heroToAct;

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
        if (state == GameState.ChooseAction)        
        {
            heroToAct = FightManager.Instance.unitToAct.GetComponent<HeroStats>();
        } 
    }

    public void hoverPrimaryAttackButton() // entweder jeder spell bekommt ein panel
    {
        SetPrimaryAttackText();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSecondaryAttackButton()
    {
        SetSecondaryAttackText();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_1Button()
    {
        SetSpell_1Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_2Button()
    {
        SetSpell_2Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_3Button()
    {
        SetSpell_3Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_4Button()
    {
        SetSpell_4Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_5Button()
    {
        SetSpell_5Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_6Button()
    {
        SetSpell_6Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_7Button()
    {
        SetSpell_7Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void hoverSpell_8Button()
    {
        SetSpell_8Text();
        ActionDescriptionPanel.SetActive(true);
    }
    public void unhoverButton() 
    {
        ActionDescriptionPanel.SetActive(false);
    }

    private void SetPrimaryAttackText()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_1;
        actionDescriptionHeaderText.text = "Primary Attack";
        actionDescriptionDescriptionText.text = "Deal " + heroToAct.damage + " damage to 1 enemy";
    }
    private void SetSecondaryAttackText()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_1;
        actionDescriptionHeaderText.text = "Secondary Attack";
        actionDescriptionDescriptionText.text = "Description";
    }
    private void SetSpell_1Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_2;
        actionDescriptionHeaderText.text = "Spell_1";
        actionDescriptionDescriptionText.text = "Heal all allies for " + heroToAct.healModifier + " health";
    }
    private void SetSpell_2Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_2;
        actionDescriptionHeaderText.text = "Spell_2";
        actionDescriptionDescriptionText.text = "Deal " + heroToAct.damage + " damage to 2 enemies";
    }
    private void SetSpell_3Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_3;
        actionDescriptionHeaderText.text = "Spell_3";
        actionDescriptionDescriptionText.text = "Description";
    }
    private void SetSpell_4Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_3;
        actionDescriptionHeaderText.text = "Spell_4";
        actionDescriptionDescriptionText.text = "Description";
    }
    private void SetSpell_5Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_4;
        actionDescriptionHeaderText.text = "Spell_5";
        actionDescriptionDescriptionText.text = "Description";
    }
    private void SetSpell_6Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_4;
        actionDescriptionHeaderText.text = "Spell_6";
        actionDescriptionDescriptionText.text = "Description";
    }
    private void SetSpell_7Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_5;
        actionDescriptionHeaderText.text = "Spell_7";
        actionDescriptionDescriptionText.text = "Description";
    }
    private void SetSpell_8Text()
    {
        ActionDescriptionPanel.transform.position = DescriptionPanelPosition_5;
        actionDescriptionHeaderText.text = "Spell_8";
        actionDescriptionDescriptionText.text = "Description";
    }
}
