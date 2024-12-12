using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDamageTestScript : MonoBehaviour
{
    private BaseHeroBehaviour baseHeroBehaviour;
    private TargetableUnit targetableUnit;
    void Awake()
    {
        baseHeroBehaviour = GetComponentInParent<BaseHeroBehaviour>();
        targetableUnit = GetComponentInParent<TargetableUnit>();
    }
    public void AttackAnimationEvent()
    {
        baseHeroBehaviour.target.TakeDamage(targetableUnit.damage);
    }
    public void StabAnimationEvent()
    {
        baseHeroBehaviour.target.TakeDamage((targetableUnit.damage)*1.5f);
    }
    public void AoEAttackAnimationEvent()
    {
        int initialEnemyCount = UnitManager.Instance.enemiesAlive.Count;
        for (int i = 0; i < initialEnemyCount; i++)
        {
            if (i >= UnitManager.Instance.enemiesAlive.Count)
            {
                break;
            }
            TargetableUnit targetStats = UnitManager.Instance.enemiesAlive[i].GetComponent<TargetableUnit>();

            targetStats.TakeDamage((targetableUnit.damage/2));            
        }
    }
    public void HealAnimationEvent()
    {
        
    }
    public void AnimationFinished()
    {
        Debug.Log("animation finished");
        FightManager.Instance.HeroEndTurn();
    }
}
