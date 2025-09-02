using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 6f;
    public float laneHeight = 1f; // hoogte van elke lane
    public float bottomY = 0f;    // Y van lane 1
    public int totalLanes = 50;   // totaal aantal lanes

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        InvokeRepeating(nameof(SpawnBird), 1f, spawnInterval);
    }

    void SpawnBird()
    {
        if (mainCam == null) return;

        // bereken zichtbare y-grenzen van de camera
        float camHeight = 2f * mainCam.orthographicSize;
        float camBottom = mainCam.transform.position.y - camHeight / 2f;
        float camTop = mainCam.transform.position.y + camHeight / 2f;

        // bepaal lanes die in beeld zijn
        int firstVisibleLane = Mathf.Max(2, Mathf.FloorToInt((camBottom - bottomY) / laneHeight) + 1);
        int lastVisibleLane = Mathf.Min(totalLanes - 1, Mathf.CeilToInt((camTop - bottomY) / laneHeight) + 1);

        if (lastVisibleLane <= firstVisibleLane) return;

        // kies random lane binnen zichtbaar gebied (exclusief spawn lane 1 en finish lane 50)
        int randomLane = Random.Range(firstVisibleLane, lastVisibleLane + 1);
        randomLane = Mathf.Clamp(randomLane, 2, totalLanes - 1);

        // bereken lane Y
        float laneY = bottomY + (randomLane - 1) * laneHeight;

        // spawn vogel
        Vector2 spawnPos = new Vector2(0f, laneY);
        Instantiate(birdPrefab, spawnPos, Quaternion.identity);
    }
}

