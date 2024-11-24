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
            //isPortalEntered = false;
            SceneManager.LoadScene(1, LoadSceneMode.Single); // for future -> change gamestate in (general)gamemanager to whatever loads the fight scene
            //SceneManager.LoadScene(1, LoadSceneMode.Additive);
            
        }    
    }
    public void OnTriggerEnter(Collider other)
        {
            Debug.Log("collision");
            if (other.gameObject.tag == "Player")
            {
                isPortalEntered = true;
            }
        } 
}
