using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private int difficulty; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.difficulty = difficulty;
            LoadFightScene();
            gameObject.SetActive(false);  
        }
    } 

    public void LoadFightScene()
    {
        GameManager.Instance.DisableRPGScene();
        SceneManager.LoadScene(1, LoadSceneMode.Additive); // for future -> change gamestate in (general)gamemanager to whatever loads the fight scene
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void SetPortalActive()
    {
        gameObject.SetActive(true);
    }
}
