using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseHeroStats : MonoBehaviour
{
    public static BaseHeroStats Instance;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public int maxSpellSlots;
    public int currentSpellSlots;
    public float healModifier;
    public bool isAlive;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        currentSpellSlots = maxSpellSlots;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
