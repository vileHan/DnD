using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOrderUIHandler : MonoBehaviour
{
    private Image[] characterImages;
    public Canvas worldCanvas; // Assign the Canvas in the inspector
    private bool isTurnOrderSetUp;
    private UnityEngine.UI.Outline outline;
    private int turnOrderIndex;

    private GameObject characterImageInstance;
    private List<GameObject> characterImageInstances = new List<GameObject>();
    
    void Awake()
    {
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
                    //outline.effectDistance = new Vector2(0,0);
                    outline.effectColor = Color.red;
                }
            }
            if (FightManager.Instance.unitToAct.tag == "Enemy")
            {
                UnitStats stats = FightManager.Instance.unitToAct.GetComponent<UnitStats>();
                if (stats.isTurn)
                {
                    outline = characterImageInstances[turnOrderIndex].GetComponent<UnityEngine.UI.Outline>();
                    //outline.effectDistance = new Vector2(0,0);
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
            int j = 0; // not needed
            isTurnOrderSetUp = true;
            foreach (KeyValuePair<GameObject, int> unit in UnitManager.Instance.unitDictionary) // iterate through sorted dictionary
            { 
                TargetableUnit turnOrderUnit = unit.Key.GetComponent<TargetableUnit>();
                
                // make characterImageInstances List contain the images to display and display the image
                characterImageInstance = Instantiate(turnOrderUnit.characterImage);
                outline = characterImageInstance.GetComponent<UnityEngine.UI.Outline>();
                outline.effectColor = Color.clear;
                characterImageInstances.Add(characterImageInstance);

                // Set it as a child of the Canvas
                characterImageInstance.transform.SetParent(worldCanvas.transform, false);

                // Adjust its RectTransform position for layout
                RectTransform rectTransform = characterImageInstance.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2(i, 465); // Adjust X position (spread images horizontally
                i += 100;
                j++;
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
}
