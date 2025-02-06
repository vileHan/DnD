using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehaviour : MonoBehaviour
{
    [SerializeField] private int difficulty; // ramdom
    [SerializeField] private GameObject player;
    public GameObject levelFinishedPanel;
    
    [SerializeField] private TransitionLoader transitionLoader;
    private ThirdPersonController thirdPersonController;

    [SerializeField] private Animator hugeDoor = null;
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
            if (gameObject.tag == "FogCollider")
            {
                //PlayFightSound();
                GameManager.Instance.isPosResetNeccessary = true;
                GameManager.Instance.difficulty = 4;
                LoadFightScene();
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
                GameManager.Instance.DisableCharacterController();
                StartCoroutine(PlayFightSound());
                GameManager.Instance.difficulty = difficulty;
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

    IEnumerator PlayFightSound()
    {
        audio.clip = initiateFight;
        audio.Play();
        yield return new WaitForSeconds(1f);
        LoadFightScene();
        gameObject.SetActive(false); 
    }
}
