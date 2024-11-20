using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public TMP_Text valueText;
    public PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valueText.text = "Speed: "+ (int)playerController.rb.velocity.magnitude;
    }
}
