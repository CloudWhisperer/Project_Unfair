using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_buttons : MonoBehaviour
{
    public void quitgame()
    {
        Application.Quit();
    }

    public void startgame()
    {
        Lives.lives = 10;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
