using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip footstepsSlow_1, footstepsSlow_2, footstepsFast_1, footstepsFast_2;
    private CharacterController characterController;
    private ThirdPersonController thirdPersonController;
    [HideInInspector] public GameObject interactableObject;
    private Animator interactableObjectAnim;

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
        if (interactableObject != null)
        {
            interactableObjectAnim = interactableObject.GetComponent<Animator>();
            interactableObjectAnim.Play("Pick-Up", 0, 0.0f);
        }
    }
    public void PlayChanceFightOrDamageOrLootEvent()
    {
        if (interactableObject != null)
        {
            interactableObjectAnim = interactableObject.GetComponent<Animator>();
            interactableObjectAnim.Play("Sarcophagus opening", 0, 0.0f);
        }
    }
    public void PlayDoorOpenEvent()
    {
        if (interactableObject != null)
        {
            interactableObjectAnim = interactableObject.GetComponent<Animator>();
            interactableObjectAnim.Play("Opening", 0, 0.0f);
        }
    }
    public void PlayExtinguishFireEvent()
    {
        if (interactableObject != null)
        {
            interactableObject.SetActive(false);
            GameObject fireGoblet = interactableObject.transform.parent.gameObject;
            EventBehaviour eventBehaviour = fireGoblet.GetComponent<EventBehaviour>();
            eventBehaviour.PlayExtinguishFireSound();
        }
    }
    public void DisableMovement()
    {
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();

        characterController.enabled = false;
        thirdPersonController.enabled = false;
    }
    public void EnableMovement()
    {
        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();

        characterController.enabled = true;
        thirdPersonController.enabled = true;
    }
}
