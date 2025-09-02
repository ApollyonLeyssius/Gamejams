using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject cloudLanePrefab;   // wolk lane prefab
    public GameObject rainbowLanePrefab; // regenboog lane prefab

    public int totalLanes = 50;      // aantal lanes in het level
    public float laneHeight = 1f;    // hoogte van 1 lane
    public float startY = 0f;        // Y van de onderste lane

    [Range(0f, 1f)]
    public float rainbowChance = 0.3f; // kans dat een lane een regenboog is

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < totalLanes; i++)
        {
            GameObject laneToSpawn;

            // Eerste en laatste lane zijn altijd wolk (spawn en finish lane)
            if (i == 0 || i == totalLanes - 1)
            {
                laneToSpawn = cloudLanePrefab;
            }
            else
            {
                // Random tussen wolk en regenboog
                laneToSpawn = Random.value < rainbowChance ? rainbowLanePrefab : cloudLanePrefab;
            }

            Vector3 spawnPos = new Vector3(0f, startY + i * laneHeight, 0f);
            Instantiate(laneToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
