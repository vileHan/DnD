using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPortal : MonoBehaviour
{
    // Start is called before the first frame update
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
            if (gameObject.tag == "Level_1")
            {
                SceneManager.LoadScene(3, LoadSceneMode.Single);  
            }
            if (gameObject.tag == "Level_Test")
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);  
            }
            
        }
    } 
}
