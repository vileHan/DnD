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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab");
            animator.SetTrigger("Attack1");
        }
    }

    public void Attack1Animation()
    {
        animator.SetTrigger("Attack1");
    }
    public void Attack2Animation()
    {
        animator.SetTrigger("Attack2");
    }
    public void Attack3Animation()
    {
        animator.SetTrigger("Attack3");
    }
    public void BuffAnimation()
    {
        animator.SetTrigger("Taunt");
    }
    // public void Cast1Animation() buggy cause missing component i cant find
    // {
    //     animator.SetTrigger("Cast1");
    // }
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
