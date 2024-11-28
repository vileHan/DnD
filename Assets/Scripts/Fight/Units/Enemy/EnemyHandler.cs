using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField]private float enemyAmount = 4;
    private float spawnDelay = 0.1f;
    public GameObject[] enemyPrefabs;
    //public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public int enemyIndex;
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
            SelectEnemy();
            yield return new WaitForSeconds(spawnDelay);
            GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPositions[i], Quaternion.identity);
            UnitManager.Instance.RegisterEnemy(enemy);
        }
        enemiesSpawned = true;
    }
    
    // void SetEnemies() // put all enemies in a List in case i want enemies not to spawn double 
    // {
    //     for (int i = 0; i < enemyPrefabs.Length; i++)
    //     {
    //         enemiesToSpawn.Add(enemyPrefabs[i]);
    //     }
    // }
    void SelectEnemy()
    {
        enemyIndex = Random.Range(0, enemyPrefabs.Length);
    }
    // void DeleteSelectedEnemyFromList(GameObject unit) // in case i decide not to spawn double enemies in scene(not in scene right now)
    // {
    //     if (enemiesToSpawn.Contains(unit))
    //     {
    //         enemiesToSpawn.Remove(unit);
    //     }
    // }
}
