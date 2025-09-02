using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Killzone"))
        {
            Debug.Log("Game Over via COLLISION");
            SceneManager.LoadScene("Gameover");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Killzone"))
        {
            Debug.Log("Game Over via TRIGGER");
            SceneManager.LoadScene("Gameover");
        }
    }

} 
// Start is called before the first frame update

    // Update is called once per frame

