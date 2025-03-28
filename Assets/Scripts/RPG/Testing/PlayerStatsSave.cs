using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsSave : MonoBehaviour
{
    public static PlayerStatsSave Instance;
    public int gold;
    public int exp;
    public int level = 2;
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
}
