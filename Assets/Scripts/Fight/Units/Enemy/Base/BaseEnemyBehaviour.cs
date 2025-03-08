using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyBehaviour : MonoBehaviour
{
    public bool isInAnimation;

    public virtual IEnumerator Action()
    {
        yield return new WaitForSeconds(0.5f);

        DecideAction();
    }
    public virtual void Attack()
    {

    }
    public virtual void DecideAction()
    {
        
    }
    public virtual void PrimaryAttackAnimation()
    {

    }
    public virtual void GotHitAnimation()
    {
        Debug.Log("gothitanimation in basescript");
    }
    public virtual void DeathAnimation()
    {
        Debug.Log("deathanimation in basescript");
    }
    public virtual void HealAnimation()
    {
        Debug.Log("healanimation in basescript");
    }
}
