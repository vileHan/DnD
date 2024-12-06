using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;
    public GameState State;

    private int dictionaryIndex = 0;

    public static event Action<GameState> OnGameStateChanged;

    public TargetableUnit unitStats;
    public GameObject unitToAct;

    private EnemyHandler enemyHandler;
    private HeroHandler heroHandler;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        enemyHandler = GameObject.FindGameObjectWithTag("EnemyHandler").GetComponent<EnemyHandler>();
        heroHandler = GameObject.FindGameObjectWithTag("HeroHandler").GetComponent<HeroHandler>();
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
            case GameState.ExecuteHeroTurn:
                HandleExecuteHeroTurn();
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
            for (int i = 0; i < GameManager.Instance.difficulty; i ++)
            {
                int reward = UnityEngine.Random.Range(2,6);
                Debug.Log("Enemy " + (i+1) + " dropped " + reward + " gold!");
                PlayerStats.Instance.gold += reward;
                int randomRoll = UnityEngine.Random.Range(0,10);
                if (randomRoll < 1)
                {
                    Debug.Log("Rare Loot!");
                }
            }
            UpdateGameState(GameState.FightWon);
        }
        else
        {
        SelectUnitTurn(); 
        UpdateGameState(GameState.ExecuteHeroTurn);   
        }    
    }
    void HandleExecuteHeroTurn()
    {

    }
    void HandleFightWon()
    {
        StartCoroutine(WinScreenTransition());
    }
    void HandleFightLost()
    {
        StartCoroutine(LoseScreenTransition());
    }
    void SelectUnitTurn()
    {
        if (unitStats != null)
        {
            unitStats.isTurn = false;
        }

        if (dictionaryIndex > (UnitManager.Instance.unitDictionary.Count-1)) // if end of dictionary go to start
        {
            dictionaryIndex = 0;
            FightUIManager.Instance.UpdateRoundCounter();
        }

        unitToAct = UnitManager.Instance.unitDictionary.ElementAt(dictionaryIndex).Key;

        unitStats = unitToAct.GetComponent<TargetableUnit>();
        Debug.Log("turn: " + unitStats.name);  
        unitStats.isTurn = true;


        dictionaryIndex++;        
    }
    void SetOrder()
    {
        UnitManager.Instance.AssignInitiative();
        UnitManager.Instance.SortDicionary();
        UnitManager.Instance.AssignUnitsInScene();
    }

    IEnumerator WinScreenTransition()
    {
        yield return new WaitForSecondsRealtime(1);
        UnitManager.Instance.DeleteAllUnitsLeft();

        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(1);
        while (!unloadOperation.isDone)
        {
            yield return null;
        }

        GameManager.Instance.EnableRPGScene();
        Debug.Log("Player Gold: " + PlayerStats.Instance.gold + "g");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    IEnumerator LoseScreenTransition()
    {
        yield return new WaitForSecondsRealtime(1);
        UnitManager.Instance.DeleteAllUnitsLeft();

        SceneManager.LoadScene(2,  LoadSceneMode.Single);
        // AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(1);
        // while (!unloadOperation.isDone)
        // {
        //     yield return null;
        // }

        // GameManager.Instance.ResetRPGScene();
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    public void HeroEndTurn()
    {
        UpdateGameState(GameState.SelectUnitTurn);
    }
}
    public enum GameState
    {
        BattleSetUp,
        SetOrder,
        ChooseAction,
        SelectUnitTurn,
        ExecuteHeroTurn,
        FightWon,
        FightLost
    }
