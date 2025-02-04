using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip footstepsSlow_1, footstepsSlow_2, footstepsFast_1, footstepsFast_2;

    [HideInInspector] public GameObject interactableObject;
    [SerializeField] private Animator interactableObjectAnim;

    public void FootstepSlow_1Sound()
    {
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsSlow_1;
        audio.Play();
    }
    public void FootstepSlow_2Sound()
    {
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsSlow_2;
        audio.Play();
    }

    public void FootstepFast_1Sound()
    {
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsFast_1;
        audio.Play();
    }
    public void FootstepFast_2Sound()
    {
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.clip = footstepsFast_2;
        audio.Play();
    }

    public void PlayUpgradeDamageEvent()
    {
        EventTriggerManager.Instance.UpgradeDamageEvent(5);

        if (interactableObject != null)
        {
            interactableObject.SetActive(false);
        }
    }
    public void PlayChanceFightOrDamageOrLootEvent()
    {
        if (interactableObject != null)
        {
            interactableObjectAnim = interactableObject.GetComponent<Animator>();
            interactableObjectAnim.Play("Sarcophagus opening", 0, 0.0f);
        }
        int chance = Random.Range(0,3); // actually bis 3
        if (chance == 0)
        {
            EventTriggerManager.Instance.ReceiveDamageEvent(10f);
        }
        if (chance == 1)
        {
            EventTriggerManager.Instance.ReceiveGoldEvent(2f, 10f);
        } 
        if (chance == 2)       
        {
            int enemyAmount = Random.Range(2,5);
            EventTriggerManager.Instance.TriggerFightEvent(enemyAmount);
        }
    }
}
