using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip creaking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CoffinEvent()
    {
        int chance = Random.Range(0,3);
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

    public void CreakSound()
    {
        audio.clip = creaking;
        audio.Play();
    }
    public void StopSound()
    {
        audio.Stop();
    }
}
