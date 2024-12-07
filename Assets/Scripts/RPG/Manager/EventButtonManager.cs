using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButtonManager : MonoBehaviour
{
    public GameObject lootPanel, lootOrNotPanel, fightOrNotPanel, chanceOrNotPanel;
    public void LootOrDamage()
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
    public void Fight()
    {
        int chance = Random.Range(2,5);
        EventTriggerManager.Instance.TriggerFightEvent(chance);
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
