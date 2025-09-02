using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 2f;
    public float[] lanes = { 2f, 4f, 6f, 8f }; // Y-posities (paden)

    void Start()
    {
        InvokeRepeating(nameof(SpawnBird), 1f, spawnInterval);
    }

    void SpawnBird()
    {
        float laneY = lanes[Random.Range(0, lanes.Length)];
        Vector2 spawnPos = new Vector2(0f, laneY); // X wordt in Bird.cs gezet
        Instantiate(birdPrefab, spawnPos, Quaternion.identity);
    }
}
