using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlotHandler : MonoBehaviour
{
    private TargetableUnit targetableUnit;
    [SerializeField] private GameObject[] emptySpellslotObjects;
    [SerializeField] private GameObject[] fullSpellslotObjects;

    void Awake()
    {
        targetableUnit = gameObject.GetComponent<TargetableUnit>();
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
        for (int i = 0; i < targetableUnit.currentSpellSlots; i++)
        {
            emptySpellslotObjects[i].SetActive(true);
        }
        for (int i = 0; i < fullSpellslotObjects.Length; i++)
        {
            fullSpellslotObjects[i].SetActive(false);
        }
        for (int i = 0; i < targetableUnit.currentSpellSlots; i++)
        {
            fullSpellslotObjects[i].SetActive(true);
        }
    }
    void SetSpellslots()
    {
        for (int i = 0; i < targetableUnit.maxSpellSlots; i++)
        {
            emptySpellslotObjects[i].SetActive(true);
        }
        for (int i = 0; i < targetableUnit.currentSpellSlots; i++)
        {
            fullSpellslotObjects[i].SetActive(true);
        }
    }
}
