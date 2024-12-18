using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitManager : MonoBehaviour
{
    public Dictionary<GameObject, int> unitDictionary = new Dictionary<GameObject, int>();
    public List<GameObject> unitsAlive = new List<GameObject>();
    public List<GameObject> heroesAlive = new List<GameObject>();
    public List<GameObject> enemiesAlive = new List<GameObject>();
    public List<GameObject> unitsInSceneOrder = new List<GameObject>();

    public static UnitManager Instance;
    
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
    
    public void RegisterHero(GameObject unit)
    {
        if (!unitsAlive.Contains(unit)) // Avoid duplicates -> dpesnt work if only checks for 1
        {
            heroesAlive.Add(unit); // list of heroes alive in fight
            unitsAlive.Add(unit); // list of all units alive in fight
        }
    }
    public void RegisterEnemy(GameObject unit)
    {
        if (!unitsAlive.Contains(unit)) // Avoid duplicates -> dpesnt work if only checks for 1
        {
            enemiesAlive.Add(unit);
            unitsAlive.Add(unit);
        }
    }
    public void RemoveUnit(GameObject unit)
    {
        if (heroesAlive.Contains(unit))
        {
            heroesAlive.Remove(unit);
        }
        if (enemiesAlive.Contains(unit))
        {
            enemiesAlive.Remove(unit);
        }
    }

    public void RemoveUnitDictionary(GameObject unit)
    {
        if (unitDictionary.ContainsKey(unit))
        {
            unitDictionary.Remove(unit);
        }
    }
    public void DeleteAllUnitsLeft()
    {
        for (int i = 0; i < unitsAlive.Count; i++)
        {
            Destroy(unitsAlive[i]);
        }
    }

    public void AssignInitiative() 
    {
        for (int i = 0; i < unitsAlive.Count; i++)
        {
            GameObject unit = unitsAlive[i];

            TargetableUnit unitStats = unit.GetComponent<TargetableUnit>();
            unitDictionary.Add(unitsAlive[i], unitStats.initiative);
        } 
    }

    public void SortDicionary()
    {
        unitDictionary = unitDictionary.OrderByDescending(key => key.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public void AssignUnitsInScene()
    {
        foreach (KeyValuePair<GameObject, int> sortedUnit in unitDictionary)
        {
            unitsInSceneOrder.Add(sortedUnit.Key);           
        }
    }
    public void DisplayDicionary()
    {
        foreach (KeyValuePair<GameObject, int> sortedUnit in unitDictionary)
        {
            Debug.Log("Dictionary: " + sortedUnit.Value + " " + sortedUnit.Key.name);            
        }
    }
}
