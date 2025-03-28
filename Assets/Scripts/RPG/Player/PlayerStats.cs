using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    public int gold;
    public int exp;
    public int level = 1;
    public int firesExtinguished;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        LoadStats();
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

    private void LoadStats()
    {
        if (PlayerStatsSave.Instance != null)
        {
            Debug.Log("load player stats");
            gold = PlayerStatsSave.Instance.gold;
            exp = PlayerStatsSave.Instance.exp;
            level = PlayerStatsSave.Instance.level;
            firesExtinguished = PlayerStatsSave.Instance.firesExtinguished;
            
        }
        
    }
    private void SaveStats() // not implemented -> for second level
    {
        if (PlayerStatsSave.Instance != null)
        {
            PlayerStatsSave.Instance.gold = gold;
            PlayerStatsSave.Instance.exp = exp;
            PlayerStatsSave.Instance.level = level;
            PlayerStatsSave.Instance.firesExtinguished = firesExtinguished;
        }
    }
}
