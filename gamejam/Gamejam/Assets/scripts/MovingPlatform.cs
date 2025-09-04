using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float range = 10f;  // hoe ver het platform beweegt vanaf start
    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        if (Vector3.Distance(startPos, transform.position) >= range)
        {
            direction *= -1; // draai om
        }
    }
}
