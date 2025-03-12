using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimations : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip itemPickup;


    public void SetObjectActiveFalse()
    {
        gameObject.SetActive(false);
    }
    public void PickUpSwordEvent()
    {
        EventTriggerManager.Instance.UpgradeDamageEvent(5);
    }
    // public void EventSound()
    // {
    //     audio.clip = itemPickup;
    //     audio.Play();
    // }
}
