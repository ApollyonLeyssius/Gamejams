using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 6f; // snelheid van de vogel

    [Header("Visuals")]
    public Transform spriteChild; // sleep je Sprite child hier in de inspector

    private Vector2 direction;

    void Start()
    {
        // Kies willekeurig of de vogel van links of rechts komt
        bool fromLeft = Random.value > 0.5f;

        if (fromLeft)
        {
            // Startpositie links
            transform.position = new Vector2(-10f, transform.position.y);
            direction = Vector2.right;

            // sprite draait 90 graden naar rechts
            spriteChild.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else
        {
            // Startpositie rechts
            transform.position = new Vector2(10f, transform.position.y);
            direction = Vector2.left;

            // sprite draait 90 graden naar links
            spriteChild.localRotation = Quaternion.Euler(0, 0, 90);
        }

        // sprite kleiner maken
        spriteChild.localScale = new Vector3(0.5f, 0.5f, 1f);
    }

    void Update()
    {
        // Beweeg de vogel
        transform.Translate(direction * speed * Time.deltaTime);

        // Als de vogel buiten het scherm is → verwijderen
        if (Mathf.Abs(transform.position.x) > 15f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");

            // speler verwijderen (later vervangen met GameManager logica)
            Destroy(other.gameObject);
        }
    }
}

