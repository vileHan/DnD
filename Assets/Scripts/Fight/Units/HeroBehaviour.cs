using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    
    void Start()
    {
        SetStats();
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitStats.isTurn)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }

    public void ChooseAction()
    {
        GameManager.Instance.UpdateGameState(GameState.ChooseAction);
    }

    void SetStats() // make this a list or something
    {
        unitStats.maxHealth = WizardStats.Instance.maxHealth;
        unitStats.currentHealth = WizardStats.Instance.currentHealth;
        unitStats.damage = WizardStats.Instance.damage;
        unitStats.maxSpellSlots = WizardStats.Instance.maxSpellSlots;
        unitStats.currentSpellSlots = WizardStats.Instance.currentSpellSlots;
        unitStats.healModifier = WizardStats.Instance.healModifier;
    }
}
