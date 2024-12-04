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
            TargetableUnit stats = FightManager.Instance.unitToAct.GetComponent<TargetableUnit>();
            if (stats.isTurn)
            {
                outline = characterImageInstances[turnOrderIndex].GetComponent<UnityEngine.UI.Outline>();
                outline.effectColor = Color.red;
            }

            turnOrderIndex++;
        }        
        

        if (state == GameState.SelectUnitTurn) // turn off outline when next unit turn
        {
            if (outline != null)
            {
                outline.effectColor = Color.yellow;
            }
        }

        if (state == GameState.SelectUnitTurn && !isTurnOrderSetUp)
        {
            int i = -392;
            isTurnOrderSetUp = true;
            foreach (KeyValuePair<GameObject, int> unit in UnitManager.Instance.unitDictionary) // iterate through sorted dictionary
            { 

                TargetableUnit turnOrderUnit = unit.Key.GetComponent<TargetableUnit>();
                characterImageInstance = Instantiate(turnOrderUnit.characterImage);
                characterImageInstances.Add(characterImageInstance);
                
                characterImageInstance.transform.SetParent(worldCanvas.transform, false);
                outline = characterImageInstance.GetComponent<UnityEngine.UI.Outline>();
                outline.effectColor = Color.yellow;
                
                // Should just set spawnpositions list so there are no spaces in between if a unit dies
                RectTransform rectTransform = characterImageInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(i, 465); // Adjust X position (spread images horizontally
                i += 106; // 100 = width of image 3 = space for the outline
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
            TargetableUnit heroStats = unit.Key.GetComponent<TargetableUnit>();
            if (!heroStats.isAlive)
            {
                GameObject tempGameObject = characterImageInstances[temp];
                characterImageInstances.Remove(characterImageInstances[temp]);
                
                Destroy(tempGameObject);
            }
        temp++;
        }
    }
}
