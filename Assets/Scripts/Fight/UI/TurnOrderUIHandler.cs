using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOrderUIHandler : MonoBehaviour
{
    public static TurnOrderUIHandler Instance;
    private Image[] characterImages;
    public Canvas worldCanvas; // Assign the Canvas in the inspector
    private bool isTurnOrderSetUp;
    private UnityEngine.UI.Outline outline;
    private int turnOrderIndex;

    private GameObject characterImageInstance;
    private List<GameObject> characterImageInstances = new List<GameObject>();
    
    void Awake()
    {
        Instance = this;
        FightManager.OnGameStateChanged += FightManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        FightManager.OnGameStateChanged -= FightManagerOnGameStateChanged;
    }
    private void FightManagerOnGameStateChanged(GameState state) 
    {
        if (state == GameState.ExecuteHeroTurn) // when unit turn
        {
            if (turnOrderIndex > (characterImageInstances.Count-1))
            {
                turnOrderIndex = 0;
            }
            if (FightManager.Instance.unitToAct.tag == "Player")
            {
                HeroStats stats = FightManager.Instance.unitToAct.GetComponent<HeroStats>();
                if (stats.isTurn)
                {
                    outline = characterImageInstances[turnOrderIndex].GetComponent<UnityEngine.UI.Outline>();
                    outline.effectColor = Color.red;
                }
            }
            if (FightManager.Instance.unitToAct.tag == "Enemy")
            {
                UnitStats stats = FightManager.Instance.unitToAct.GetComponent<UnitStats>();
                if (stats.isTurn)
                {
                    outline = characterImageInstances[turnOrderIndex].GetComponent<UnityEngine.UI.Outline>();
                    outline.effectColor = Color.red;
                }
            }
            turnOrderIndex++;
        }        
        

        if (state == GameState.SelectUnitTurn) // turn off outline when next unit turn
        {
            if (outline != null)
            {
                outline.effectColor = Color.clear;
            }
        }

        if (state == GameState.SelectUnitTurn && !isTurnOrderSetUp)
        {
            int i = -350;
            isTurnOrderSetUp = true;
            foreach (KeyValuePair<GameObject, int> unit in UnitManager.Instance.unitDictionary) // iterate through sorted dictionary
            { 
                if (unit.Key.tag == "Player")
                {
                    HeroStats turnOrderUnit = unit.Key.GetComponent<HeroStats>();
                    characterImageInstance = Instantiate(turnOrderUnit.characterImage);
                    characterImageInstances.Add(characterImageInstance);
                }
                if (unit.Key.tag == "Enemy")
                {
                    UnitStats turnOrderUnit = unit.Key.GetComponent<UnitStats>();
                    characterImageInstance = Instantiate(turnOrderUnit.characterImage);
                    characterImageInstances.Add(characterImageInstance);
                }
                
                characterImageInstance.transform.SetParent(worldCanvas.transform, false);
                outline = characterImageInstance.GetComponent<UnityEngine.UI.Outline>();
                outline.effectColor = Color.clear;
                
                // Should just set spawnpositions list so there are no spaces in between if a unit dies
                RectTransform rectTransform = characterImageInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(i, 465); // Adjust X position (spread images horizontally
                i += 103; // 100 = width of image 3 = space for the outline
            }
        }
    }
    void Start()
    {
        if (worldCanvas == null)
        {
            Debug.LogError("Canvas is not assigned!");
            return;
        } 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeleteTurnImage();
        }
    }

    public void DeleteTurnImage()
    {
        int temp = 0;
        foreach (KeyValuePair<GameObject, int> unit in UnitManager.Instance.unitDictionary)
        {         
            if (unit.Key.tag == "Player")
            {
                HeroStats heroStats = unit.Key.GetComponent<HeroStats>();
                if (!heroStats.isAlive)
                {
                    Debug.Log("remove: " + characterImageInstances[temp]);
                    GameObject tempGameObject = characterImageInstances[temp];
                    characterImageInstances.Remove(characterImageInstances[temp]);
                    
                    Destroy(tempGameObject);
                }
            }
            if (unit.Key.tag == "Enemy")
            {
                UnitStats unitStats = unit.Key.GetComponent<UnitStats>();
                if (!unitStats.isAlive)
                {
                    Debug.Log("remove: " + characterImageInstances[temp]);
                    GameObject tempGameObject = characterImageInstances[temp];
                    characterImageInstances.Remove(characterImageInstances[temp]);
                    
                    Destroy(tempGameObject);
                }
            }
            temp++;
        }
    }
}
