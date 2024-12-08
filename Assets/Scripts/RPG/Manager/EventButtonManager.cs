using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButtonManager : MonoBehaviour
{
    public GameObject lootPanel, lootOrNotPanel, fightOrNotPanel, chanceOrNotPanel;
    public void GetLootOrDamage()
    {
        int chance = Random.Range(0,2);
        if (chance == 0)
        {
            EventTriggerManager.Instance.ReceiveDamageEvent(10f);
        }
        if (chance == 1)
        {
            EventTriggerManager.Instance.ReceiveGoldEvent(2f, 10f);
        }        
    }
    public void StartFight()
    {
        int enemyAmount = Random.Range(2,5);
        EventTriggerManager.Instance.TriggerFightEvent(enemyAmount);
    }
    public void GetLoot()
    {
        EventTriggerManager.Instance.ReceiveGoldEvent(1, 6);
    }
    public void ChanceFightOrDamageOrLoot()
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


    public void DisablePanels()
    {
        lootPanel.SetActive(false);
        lootOrNotPanel.SetActive(false);
        fightOrNotPanel.SetActive(false);
        chanceOrNotPanel.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
