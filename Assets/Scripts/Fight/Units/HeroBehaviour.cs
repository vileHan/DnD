using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField] private UnitStats unitStats;

    [SerializeField] private Outline outline;

    
    void Start()
    {
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
