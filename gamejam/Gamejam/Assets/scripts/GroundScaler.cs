using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundPrefab; // prefab van je wolk/ground tile
    public int numberOfLanes = 50;  // totaal aantal lanes
    public float laneHeight = 1f;   // hoogte van 1 lane
    public float startY = 0f;       // beginpositie Y (onderste lane)
    public float startX = 0f;       // beginpositie X
    public float laneWidth = 1f;    // breedte van 1 tile

    void Start()
    {
        for (int i = 0; i < numberOfLanes; i++)
        {
            Vector3 spawnPos = new Vector3(startX, startY + i * laneHeight, 0);
            Instantiate(groundPrefab, spawnPos, Quaternion.identity);
        }
    }
}
