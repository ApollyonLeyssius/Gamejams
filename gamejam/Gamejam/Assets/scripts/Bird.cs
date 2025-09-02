using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 6f;                 // snelheid van de vogel
    private Vector2 direction;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // Kies random of de vogel van links of rechts komt
        bool fromLeft = Random.value > 0.5f;

        if (fromLeft)
        {
            transform.position = new Vector2(-10f, transform.position.y); // start links
            direction = Vector2.right;
            spriteRenderer.flipX = false; // kijkt naar rechts
        }
        else
        {
            transform.position = new Vector2(10f, transform.position.y);  // start rechts
            direction = Vector2.left;
            spriteRenderer.flipX = true;  // kijkt naar links
        }
    }

    void Update()
    {
        // Beweeg de vogel
        transform.Translate(direction * speed * Time.deltaTime);

        // Verwijder als vogel buiten beeld is
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
            Destroy(other.gameObject); // speler verwijderen, later GameManager triggeren
        }
    }
}
