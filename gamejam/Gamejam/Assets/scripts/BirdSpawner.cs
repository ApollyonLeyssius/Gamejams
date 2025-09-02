using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 4f; // spawn elke 4 seconden
    public float[] lanes = { 1f, 2f, 3f, 4f, 5f, 6f }; // voorbeeld lanes (Y-posities)

    void Start()
    {
        InvokeRepeating(nameof(SpawnBird), 1f, spawnInterval);
    }

    void SpawnBird()
    {
        if (lanes.Length <= 2) return; // als er te weinig lanes zijn, stop

        // Kies random lane tussen index 1 en lanes.Length - 2 (dus sla eerste & laatste lane over)
        int randomIndex = Random.Range(1, lanes.Length - 1);
        float laneY = lanes[randomIndex];

        // X-positie wordt in Bird.cs bepaald (links of rechts), dus alleen Y hier instellen
        Vector2 spawnPos = new Vector2(0f, laneY);
        Instantiate(birdPrefab, spawnPos, Quaternion.identity);
    }
}
