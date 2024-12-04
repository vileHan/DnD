using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlotHandler : MonoBehaviour
{
    private HeroStats heroStats;
    [SerializeField] private GameObject[] emptySpellslotObjects;
    [SerializeField] private GameObject[] fullSpellslotObjects;

    void Awake()
    {
        heroStats = gameObject.GetComponent<HeroStats>();
    }

    void Start()
    {
        SetSpellslots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSpellslots() // there has to be a better way but im dumb :( (could count from .Length down)
    {
        for (int i = 0; i < heroStats.currentSpellSlots; i++)
        {
            emptySpellslotObjects[i].SetActive(true);
        }
        for (int i = 0; i < fullSpellslotObjects.Length; i++)
        {
            fullSpellslotObjects[i].SetActive(false);
        }
        for (int i = 0; i < heroStats.currentSpellSlots; i++)
        {
            fullSpellslotObjects[i].SetActive(true);
        }
    }
    void SetSpellslots()
    {
        for (int i = 0; i < heroStats.maxSpellSlots; i++)
        {
            emptySpellslotObjects[i].SetActive(true);
        }
        for (int i = 0; i < heroStats.currentSpellSlots; i++)
        {
            fullSpellslotObjects[i].SetActive(true);
        }
    }
}
