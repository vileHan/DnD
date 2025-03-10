using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int gold;
    public int exp;
    private int level = 1;
    public int firesExtinguished;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetStats()
    {
        firesExtinguished = 0;
        gold = 0;
    }
    public void levelUpCheck()
    {
        switch (level)
        {
            case 1:
                if (exp >= 1000)
                {
                    level++;
                    exp -= 1000;
                }
                break;
            case 2:
                if (exp >= 2000)
                {
                    level++;
                    exp -= 2000;
                }
                break;
            default:
                Debug.Log("no level assigned");
                break;
        }
    }
}
