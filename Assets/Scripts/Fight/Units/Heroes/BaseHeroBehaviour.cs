using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHeroBehaviour : MonoBehaviour
{
    [HideInInspector] public TargetableUnit target;
    public int heroAttackingIndex = 0;
    public void SetAttackIndex(int index)
    {
        heroAttackingIndex = index;
    }
    public void ResetAttackIndex()
    {
        heroAttackingIndex = 0;
    }

    public virtual void PrimaryAttack(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void SecondaryAttack(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_1Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_2Against(TargetableUnit target) // abstract instead of virtual
    {

    }
    public virtual void Spell_3Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_4Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_5Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_6Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_7Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_8Against(TargetableUnit target) // abstract instead of virtual
    {
        
    }
}
