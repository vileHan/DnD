using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    private FightUIManager fightUIManager;

    
    void Start()
    {
        fightUIManager = GameObject.FindGameObjectWithTag("FightUIManager").GetComponent<FightUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseAction()
    {
        GameManager.Instance.UpdateGameState(GameState.ChooseAction);
        unitStats.isTurn = false;
    }
}
