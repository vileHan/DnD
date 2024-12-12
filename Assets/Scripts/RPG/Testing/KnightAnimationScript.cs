using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnightAnimationScript : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        //animator.SetTrigger("Block");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Attack1Animation()
    {
        animator.SetTrigger("Attack1");
    }
    public void HalfAttackAnimation()
    {
        animator.SetTrigger("HalfAttack");
    }
    public void Attack2Animation()
    {
        animator.SetTrigger("Attack2");
    }
    public void Attack3Animation()
    {
        animator.SetTrigger("Attack3");
    }
    public void TauntAnimation()
    {
        animator.SetTrigger("Taunt");
    }
    public void Cast1Animation() 
    {
        animator.SetTrigger("Cast1");
    }
    public void Cast2Animation()
    {
        animator.SetTrigger("Cast2");
    }
    public void GotHitAnimation()
    {
        animator.SetTrigger("GotHit");
    }
    public void DeathAnimation()
    {
        animator.SetTrigger("Death");
    }
    public void BlockAnimation()
    {
        animator.SetTrigger("Block");
    }
}
