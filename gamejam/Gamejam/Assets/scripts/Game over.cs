using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
public void QuitGame()
    {
        Application.Quit();
    }

    public void Mainmenu()
    { 
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Julianscene");
    }
}
