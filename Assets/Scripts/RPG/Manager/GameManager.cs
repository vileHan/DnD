using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CharacterController characterController;
    public ThirdPersonController thirdPersonController;
    public Animator playerAnimator;
    public static GameManager Instance;
    public EventTriggerManager eventTriggerManager;
    public int difficulty;
    public bool isPosResetNeccessary;
    [SerializeField] private GameObject thirdPersonCamera, eventSystem, mainCamera, player, settingsPanel;
    private Camera cam;

    [HideInInspector] public GameObject initiateFightCollider;
    public AudioSource audio;
    public AudioClip initiateFight;

    //public GameObject HeroStatManager;
    private MonkStats monkStats;
    private PaladinStats paladinStats;
    private RogueStats rogueStats;
    private WizardStats wizardStats;

    private bool isGamePaused;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = mainCamera.GetComponent<Camera>();
        // monkStats = HeroStatManager.GetComponent<MonkStats>();
        // paladinStats = HeroStatManager.GetComponent<PaladinStats>();
        // rogueStats = HeroStatManager.GetComponent<RogueStats>();
        // wizardStats = HeroStatManager.GetComponent<WizardStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else 
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void DisableRPGScene()
    {   
        if (isPosResetNeccessary)
        {
            player.transform.position = new Vector3(500f, 0f, 75f);
        }
        thirdPersonCamera.SetActive(false);
        cam.enabled = false;
        player.SetActive(false);
        eventSystem.SetActive(false);
    }
    public void EnableRPGScene()
    {
        GameManager.Instance.isPosResetNeccessary = false;
        thirdPersonCamera.SetActive(true);
        cam.enabled = true;
        player.SetActive(true);
        eventSystem.SetActive(true);
        AudioManager.Instance.PlayTrack(0);
    }
    public void ResetRPGScene()
    {
        player.transform.position = new Vector3(0f, 0f, -45f);
        thirdPersonCamera.SetActive(true);
        mainCamera.SetActive(true);
        player.SetActive(true);
        eventSystem.SetActive(true);

        monkStats.ResetStats();
        paladinStats.ResetStats();
        rogueStats.ResetStats();
        wizardStats.ResetStats();

        eventTriggerManager.ResetPortals();
    }
    public void EnableCharacterController()
    {
        characterController = player.GetComponent<CharacterController>();
        thirdPersonController = player.GetComponent<ThirdPersonController>();
        playerAnimator = player.GetComponent<Animator>();
        
        characterController.enabled = true;

        thirdPersonController.enabled = true;

        playerAnimator.SetBool("idle", false);
    }
    public void DisableCharacterController()
    {
        characterController = player.GetComponent<CharacterController>();
        thirdPersonController = player.GetComponent<ThirdPersonController>();
        playerAnimator = player.GetComponent<Animator>();
        
        characterController.enabled = false;

        thirdPersonController.enabled = false;

        playerAnimator.SetBool("idle", true);
    }

    public void LoadFightScene()
    {
        
        DisableRPGScene();
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
    public IEnumerator PlayInitiateFight()
    {
        DisableCharacterController(); 
        audio.clip = initiateFight;
        audio.Play();
        AudioManager.Instance.StopTrack(0);
        yield return new WaitForSeconds(1f);
        AudioManager.Instance.PlayTrack(4);
        audio.Stop();
        LoadFightScene();
        if (initiateFightCollider != null)
        {
            initiateFightCollider.SetActive(false);
        }
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}