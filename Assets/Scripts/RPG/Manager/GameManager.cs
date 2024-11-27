using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject thirdPersonCamera, eventSystem, cameraHolder, player;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
}
