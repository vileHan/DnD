using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHandler : MonoBehaviour
{
    private int heroAmount = 1;
    public GameObject[] heroPrefabs;
    [SerializeField]private Vector3[] spawnPositions;
    public bool heroesSpawned;

    void Start()
    {
        for(int i = 0; i < heroAmount; i++)
        {
            GameObject hero = Instantiate(heroPrefabs[i], spawnPositions[i], Quaternion.identity);
            UnitManager.Instance.RegisterHero(hero);
        }
        heroesSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTest()
    {
        foreach (GameObject unit in UnitManager.Instance.unitsAlive)
        {   
            Debug.Log("Unit in scene: " + unit.name);
        }

    }
}
