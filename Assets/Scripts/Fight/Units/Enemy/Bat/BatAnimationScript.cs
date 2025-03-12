using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimationScript : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack1Animation();
            Debug.Log("space");
        }
    }

    public void Attack1Animation()
    {
        animator.SetTrigger("attack1");
    }
    public void Attack2Animation()
    {
        animator.SetTrigger("attack2");
    }
    public void DeathAnimation()
    {
        animator.SetTrigger("death");
    }
    public void GotHitAnimation()
    {
        animator.SetTrigger("gotHit");
    }
    public void DodgeAnimation()
    {
        animator.SetTrigger("dodge");
    }
    public void TauntAnimation()
    {
        animator.SetTrigger("taunt");
    }
}
