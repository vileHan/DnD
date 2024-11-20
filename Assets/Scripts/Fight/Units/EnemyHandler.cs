using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    private int enemyAmount = 4;
    public GameObject[] enemyPrefabs;
    [SerializeField]private Vector3[] spawnPositions;

    void Start()
    {
        for(int i = 0; i < enemyAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[i], spawnPositions[i], Quaternion.identity);
            UnitManager.Instance.RegisterUnit(enemy);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
