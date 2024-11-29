using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHandler : MonoBehaviour
{
    private int heroAmount = 4;
    public GameObject[] heroPrefabs;
    [SerializeField]private Vector3[] spawnPositions;
    public bool heroesSpawned;

    void Start()
    {
        for(int i = 0; i < heroAmount; i++)
        {
            GameObject hero = Instantiate(heroPrefabs[i], spawnPositions[i], Quaternion.identity);
            Debug.Log(hero.name);
            HeroStats heroStats = hero.GetComponent<HeroStats>();      
            if (!heroStats.isAlive)
            {
                hero.SetActive(false);
            }      
            else
            {
                UnitManager.Instance.RegisterHero(hero); 
            }
        }
        heroesSpawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
