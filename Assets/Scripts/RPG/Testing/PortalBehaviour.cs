using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    public bool isPortalEntered;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPortalEntered)
        {
            LoadFightScene();
            Destroy(gameObject);  
        }    
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPortalEntered = true;
        }
    } 

    public void LoadFightScene()
    {
        isPortalEntered = false;
        GameManager.Instance.DisableRPGScene();
        SceneManager.LoadScene(1, LoadSceneMode.Additive); // for future -> change gamestate in (general)gamemanager to whatever loads the fight scene
        //SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
