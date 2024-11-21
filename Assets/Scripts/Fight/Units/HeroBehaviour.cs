using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;
    [SerializeField] private HealthbarHandler healthbarHandler;
    private FightUIManager fightUIManager;

    [SerializeField] private Outline outline;

    
    void Start()
    {
        fightUIManager = GameObject.FindGameObjectWithTag("FightUIManager").GetComponent<FightUIManager>();
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unitStats.isTurn)
        {
            outline.enabled = true;
        }
        else
        {
            outline.enabled = false;
        }
    }

    public void ChooseAction()
    {
        GameManager.Instance.UpdateGameState(GameState.ChooseAction);
    }
}
