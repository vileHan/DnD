using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private int difficulty; // ramdom
    [SerializeField] private GameObject player;
    public GameObject levelFinishedPanel;
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
            if (gameObject.tag == "FogCollider")
            {
                GameManager.Instance.isPosResetNeccessary = true;
                GameManager.Instance.difficulty = 4;
                LoadFightScene();
                Debug.Log("collide");
            }
            else if (gameObject.tag == "PortalEventCollider")
            {
                //cameraEvent
                CharacterController controller = player.GetComponent<CharacterController>();
                controller.enabled = false;

                player.transform.position = new Vector3(544f, 9f, 755.3f);

                controller.enabled = true;
                gameObject.SetActive(false); 
            }
            else if (gameObject.tag == "LevelFinishedCollider")
            {
                levelFinishedPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else 
            {
                GameManager.Instance.difficulty = difficulty;
                LoadFightScene();
                gameObject.SetActive(false); 
            }
             
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
