using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class TargetableUnit : MonoBehaviour
{
    public MMFeedbacks SmallHitFeedback;
    public MMFeedbacks MediumHitFeedback;
    public MMFeedbacks LargeHitFeedback;
    [SerializeField] private GameObject healthbar;
    [SerializeField] public GameObject characterImage;
    public float test = 101;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public float armor;
    public int maxSpellSlots;
    public int currentSpellSlots; 
    public float healModifier;

    public bool isTurn;
    public bool isAlive;

    public int initiative;
    public int panelIndex;

    void Start()
    {

    }
    public virtual void TakeDamage(float damage)
    {
        
    }
    public virtual void Heal(float healModifier)
    {

    }
    public virtual void Die()
    {

    }

    public virtual void MouseEnterUnit()
    {

    }
    public virtual void MouseExitUnit()
    {

    }
    public virtual void SetStatsToDisplay()
    {
        
    }
    public virtual int SpellCostCalculator()
    {
        return initiative;
    }
    public virtual void DisableHealthbar()
    {
        healthbar.SetActive(false);
    }
}
