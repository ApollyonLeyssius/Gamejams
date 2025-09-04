using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class movements : MonoBehaviour
{
    private float lastMoveTime = 0f;
    private float moveCooldown = 0.25f;
    public TMP_Text score;
    public float scorevalue = 0;
    public new GameObject camera;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            && Time.time - lastMoveTime >= moveCooldown)
        {
            transform.Translate(0, 1f, 0);
            lastMoveTime = Time.time;

            scorevalue += 1;
            score.text = "" + scorevalue;
            camera.transform.Translate(0, 1f, 0);
        }

        if (scorevalue == 50)
        {
            SceneManager.LoadScene("win");
        }


        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            && Time.time - lastMoveTime >= moveCooldown)
        {
            transform.Translate(1f, 0, 0);
            lastMoveTime = Time.time;
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        && Time.time - lastMoveTime >= moveCooldown)
        {
            transform.Translate(-1f, 0, 0);
            lastMoveTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("killzone"))
        {
            SceneManager.LoadScene("Gameover");
        }
    }

}
