using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public string mainMenuLevel;
    public GameObject pauseMenu;
   

    public void Pausegame()
    {
        Time.timeScale = 0f; // binary function, 0 means stop time, 1 means time resumes normally
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().Reset2();
        pauseMenu.SetActive(false);
    }

    public void QuittoMain()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(mainMenuLevel);
    }
}
