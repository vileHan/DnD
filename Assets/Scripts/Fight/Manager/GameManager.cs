using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine.SceneManagement;

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
        UpdateGameState(GameState.BattleSetUp);
    }

    // Update is called once per frame
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        OnGameStateChanged?.Invoke(newState);

        switch(newState)
        {
            case GameState.BattleSetUp:
                StartCoroutine(HandleBattleSetUp());
                break;
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
            case GameState.FightWon:
                HandleFightWon();
                break;
            case GameState.FightLost:
                HandleFightLost();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }
    
    IEnumerator HandleBattleSetUp()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EnemyHandler enemyHandler = GameObject.FindGameObjectWithTag("EnemyHandler").GetComponent<EnemyHandler>();
        HeroHandler heroHandler = GameObject.FindGameObjectWithTag("HeroHandler").GetComponent<HeroHandler>();
        while (!heroHandler.heroesSpawned || !enemyHandler.enemiesSpawned)
        {
            yield return null;
        }

        UpdateGameState(GameState.SetOrder);       
    }
    void HandleChooseAction()
    {
        
    }
    void HandleSetOrder()
    {
        SetOrder();
        UpdateGameState(GameState.SelectUnitTurn);
    }
    void HandleSelectUnitTurn()
    {       
        if (UnitManager.Instance.heroesAlive.Count == 0)
        {
            UpdateGameState(GameState.FightLost);
        }
        else if (UnitManager.Instance.enemiesAlive.Count == 0)
        {
            UpdateGameState(GameState.FightWon);
        }
        else
        {
        SelectUnitTurn(); 
        UpdateGameState(GameState.ExecuteUnitTurn);   
        }    
    }
    void HandleExecuteUnitTurn()
    {

    }
    void HandleFightWon()
    {
        StartCoroutine(EndScreenTransition());
    }
    void HandleFightLost()
    {
        StartCoroutine(EndScreenTransition());
    }
    void SelectUnitTurn()
    {
        if (activeUnitStats != null)
        {
            activeUnitStats.isTurn = false;
        }
            
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

    IEnumerator EndScreenTransition()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.UnloadSceneAsync(1);
        UnitManager.Instance.DeleteAllUnitsLeft();
        GeneralGameManager.Instance.EnableRPGScene();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
    public enum GameState
    {
        BattleSetUp,
        SetOrder,
        ChooseAction,
        SelectUnitTurn,
        ExecuteUnitTurn,
        FightWon,
        FightLost
    }
