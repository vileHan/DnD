using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FightUIManager : MonoBehaviour
{
    public GameObject ChooseActionPanel;
    
    public bool heroAttacking;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    void OnDestroy() 
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        ChooseActionPanel.SetActive(state == GameState.ChooseAction);        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attack()
    {        
        heroAttacking = true; 
    }
}
