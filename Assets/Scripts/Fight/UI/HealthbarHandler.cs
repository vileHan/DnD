using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarHandler : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;
    
    private float reduceSpeed;
    private float target;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        healthbarSprite.fillAmount = Mathf.MoveTowards(healthbarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        reduceSpeed = 1.5f;
        target = currentHealth / maxHealth;
        
    }
    public void SetHealthbar(float maxHealth, float currentHealth)
    {
        reduceSpeed = 10000f;
        target = currentHealth / maxHealth;
    }
}
