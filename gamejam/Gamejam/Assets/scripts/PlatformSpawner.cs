using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float yOffset = 0f; // hoe hoog boven de lane

    void Start()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        RainbowLane[] rainbowLanes = FindObjectsOfType<RainbowLane>();

        foreach (RainbowLane lane in rainbowLanes)
        {
            Vector3 spawnPos = lane.transform.position + Vector3.up * yOffset;
            Instantiate(platformPrefab, spawnPos, Quaternion.identity);
        }
    }
}
