using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAnimationEvents : MonoBehaviour
{
    private TargetableUnit targetableUnit;

    void Awake()
    {
        targetableUnit = GetComponentInParent<TargetableUnit>();
    }
    public void DemonAttackAnimationEvent()
    {
        GameObject targetedHero = UnitManager.Instance.heroesAlive[Random.Range(0, UnitManager.Instance.heroesAlive.Count)]; // random right now -> later maybe look for target with lowest health
        TargetableUnit targetHeroStats = targetedHero.GetComponent<TargetableUnit>();  
        targetHeroStats.TakeDamage(targetableUnit.damage);
    }
    public void AnimationFinished()
    {   
        FightManager.Instance.UpdateGameState(GameState.SelectUnitTurn);
    }
}
