using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    bool gamePaused;

    public void Start()
    {
        gamePaused = false;
    }

    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void OnClick()
    {
        if (gamePaused)
        {
            ResumeGame();
        }
        else PauseGame();
    }
}
