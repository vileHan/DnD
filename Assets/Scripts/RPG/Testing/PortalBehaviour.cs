using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private int difficulty; // random
    
    public GameObject levelFinishedPanel;
    
    private ThirdPersonController thirdPersonController;

    private Animator hugeDoor = null;
    [SerializeField] private bool openingTrigger = false;
    [SerializeField] private bool closingTrigger = false;
    public AudioSource audio;
    public AudioClip initiateFight;

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
            GameManager.Instance.initiateFightCollider = this.gameObject;
            if (gameObject.tag == "FogCollider")
            {
                //PlayFightSound();
                GameManager.Instance.isPosResetNeccessary = true;
                GameManager.Instance.difficulty = 4;
                GameManager.Instance.StartCoroutine(GameManager.Instance.PlayInitiateFight());
            }
            else if (gameObject.tag == "PortalEventCollider")
            {
                if (closingTrigger)
                {
                    hugeDoor.Play("Closing", 0, 0.0f);
                    gameObject.SetActive(false); 
                }

            }
            else if (gameObject.tag == "LevelFinishedCollider")
            {
                levelFinishedPanel.gameObject.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else 
            {
                GameManager.Instance.difficulty = difficulty;
                GameManager.Instance.StartCoroutine(GameManager.Instance.PlayInitiateFight());
            }
             
        }
    } 

    public void LoadFightScene()
    {
        GameManager.Instance.DisableRPGScene();
        SceneManager.LoadScene(1, LoadSceneMode.Additive); // for future -> change gamestate in (general)gamemanager to whatever loads the fight scene
    }

    public void SetPortalActive()
    {
        gameObject.SetActive(true);
    }

    IEnumerator PlayFightStart()
    {
        Debug.Log("test");
        audio.clip = initiateFight;
        audio.Play();
        Debug.Log("test1");
        yield return new WaitForSeconds(1f);
        Debug.Log("test2");
        LoadFightScene();
        gameObject.SetActive(false); 
    }
}
