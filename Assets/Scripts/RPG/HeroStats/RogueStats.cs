using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueStats : MonoBehaviour
{
    public static RogueStats Instance;

    public float maxHealth;
    public float currentHealth;
    public float damage;
    public int maxSpellSlots;
    public int currentSpellSlots;
    public float healModifier;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
