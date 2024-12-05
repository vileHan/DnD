using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHandler : MonoBehaviour
{
    private int heroAmount = 4;
    public GameObject[] heroPrefabs;
    [SerializeField]private Vector3[] spawnPositions;
    public bool heroesSpawned;

    void Awake()
    {
        //heroAmount = GameManager.Instance.difficulty;
    }

    
    void Start()
    {
        for(int i = 0; i < heroAmount; i++)
        {
            GameObject hero = Instantiate(heroPrefabs[i], spawnPositions[i], Quaternion.identity);
            TargetableUnit heroStats = hero.GetComponent<TargetableUnit>();    
            if (!heroStats.isAlive)
            {
                hero.SetActive(false);
            }      
            else // has to be registered when dead as well? to get deleted when round is over
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
