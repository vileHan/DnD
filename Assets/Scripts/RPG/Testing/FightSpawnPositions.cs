using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSpawnPositions : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}
