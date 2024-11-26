using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    private float enemyAmount = 4;
    private float spawnDelay = 0.1f;
    public GameObject[] enemyPrefabs;
    public bool enemiesSpawned;
    [SerializeField]private Vector3[] spawnPositions;

    void Start()
    { 
        StartCoroutine(Spawn());             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for(int i = 0; i < enemyAmount; i++)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject enemy = Instantiate(enemyPrefabs[i], spawnPositions[i], Quaternion.identity);
            UnitManager.Instance.RegisterEnemy(enemy);
        }
        enemiesSpawned = true;
    }
    void SetEnemyStats()
    {
        
    }
}
