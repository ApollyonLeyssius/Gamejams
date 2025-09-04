using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneScaler : MonoBehaviour
{
    public float laneHeight = 1f; // hoogte van 1 lane

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // originele sprite hoogte in units
        float spriteHeight = sr.sprite.bounds.size.y;

        // scale berekenen zodat het precies 1 lane hoog is
        float scaleY = laneHeight / spriteHeight;

        // schaal toepassen (X blijft ongewijzigd)
        transform.localScale = new Vector3(transform.localScale.x, scaleY, 1f);
    }
}

