using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public EventTriggerHandler eventTriggerHandler;

    [SerializeField] private GameObject thirdPersonCamera, eventSystem, cameraHolder, player;

    public GameObject HeroStatManager;
    private MonkStats monkStats;
    private PaladinStats paladinStats;
    private RogueStats rogueStats;
    private WizardStats wizardStats;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        monkStats = HeroStatManager.GetComponent<MonkStats>();
        paladinStats = HeroStatManager.GetComponent<PaladinStats>();
        rogueStats = HeroStatManager.GetComponent<RogueStats>();
        wizardStats = HeroStatManager.GetComponent<WizardStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableRPGScene()
    {
        thirdPersonCamera.SetActive(false);
        cameraHolder.SetActive(false);
        player.SetActive(false);
        eventSystem.SetActive(false);
    }
    public void EnableRPGScene()
    {
        thirdPersonCamera.SetActive(true);
        cameraHolder.SetActive(true);
        player.SetActive(true);
        eventSystem.SetActive(true);
    }
    public void ResetRPGScene()
    {
        player.transform.position = new Vector3(0f, 0f, -45f);
        thirdPersonCamera.SetActive(true);
        cameraHolder.SetActive(true);
        player.SetActive(true);
        eventSystem.SetActive(true);

        monkStats.ResetStats();
        paladinStats.ResetStats();
        rogueStats.ResetStats();
        wizardStats.ResetStats();

        eventTriggerHandler.ResetPortals();
    }
}