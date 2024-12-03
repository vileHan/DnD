using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetableUnit : MonoBehaviour
{
    [SerializeField] public GameObject characterImage;
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
}
