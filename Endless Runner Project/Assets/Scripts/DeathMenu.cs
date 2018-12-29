using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset2();
    }

    public void QuittoMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }

}
