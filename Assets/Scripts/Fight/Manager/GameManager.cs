using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    private int dictionaryIndex = 0;

    public static event Action<GameState> OnGameStateChanged;

    public UnitStats activeUnitStats;
    public float attackingUnitDamage;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.SetOrder);
    }

    // Update is called once per frame
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch(newState)
        {
            case GameState.SetOrder:
                HandleSetOrder();
                break;
            case GameState.SelectUnitTurn:
                HandleSelectUnitTurn();
                break;
            case GameState.ExecuteUnitTurn:
                HandleExecuteUnitTurn();
                break;
            case GameState.ChooseAction:
                HandleChooseAction();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
    
    void HandleChooseAction()
    {

    }
    async void HandleSetOrder()
    {
        await Task.Delay(100);
        SetOrder();
        UpdateGameState(GameState.SelectUnitTurn);
    }
    async void HandleSelectUnitTurn()
    {             
        await Task.Delay(500);

        SelectUnitTurn(); 
        UpdateGameState(GameState.ExecuteUnitTurn);       
    }
    void HandleExecuteUnitTurn()
    {

    }
    void SelectUnitTurn()
    {
        if (dictionaryIndex > (UnitManager.Instance.unitDictionary.Count-1)) // if end of dictionary go to start
        {
            dictionaryIndex = 0;
        }

        UnitManager.Instance.unitToAct = UnitManager.Instance.unitDictionary.ElementAt(dictionaryIndex).Key;
        activeUnitStats = UnitManager.Instance.unitToAct.GetComponent<UnitStats>();  
        activeUnitStats.isTurn = true;


        dictionaryIndex++;
    }
    void SetOrder()
    {
        UnitManager.Instance.AssignInitiative();
        UnitManager.Instance.SortDicionary();
    }
}
    public enum GameState
    {
        SetOrder,
        ChooseAction,
        SelectUnitTurn,
        ExecuteUnitTurn
    }
