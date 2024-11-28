using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHeroBehaviour : MonoBehaviour
{
    public int heroAttackingIndex = 0;
    public void SetAttackIndex(int index)
    {
        heroAttackingIndex = index;
        Debug.Log("set index: " + heroAttackingIndex);
    }
    public void ResetAttackIndex()
    {
        Debug.Log("reset Index");
        heroAttackingIndex = 0;
    }

    public virtual void PrimaryAttackEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void SecondaryAttackEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_1AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_2AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {

    }
    public virtual void Spell_3AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_4AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_5AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_6AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_7AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
    public virtual void Spell_8AgainstEnemy(EnemyBehaviour enemy) // abstract instead of virtual
    {
        
    }
}
