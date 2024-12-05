using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerHandler : MonoBehaviour
{
    int level = 6;
    public GameObject[] portal; //(eventtrigger)
    public List<GameObject> trigger;
    private float spawnZ = -30;
    void Start()
    {
        for (int i = 0; i < level; i++)
        {
            GameObject temp = Instantiate(portal[i], new Vector3(0f, 2.5f, spawnZ + (i * 15)), Quaternion.identity);
            trigger.Add(temp);
            trigger[i].transform.SetParent(this.transform, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetPortals()
    {
        for (int i = 0; i < trigger.Count; i++)
        {
            trigger[i].SetActive(true);
        }
        
    }
}
