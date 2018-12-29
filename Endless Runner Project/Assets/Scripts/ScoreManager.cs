using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing;


	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("HighScore"))  // if anything in our player prefs called highscore, then true, if not no highscore
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(scoreIncreasing)
        {
           scoreCount += pointsPerSecond * Time.deltaTime; // timeperframe 
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount); //puts it in the save state of the application. So that upon starting and ending, the highscore is always kept
        }

        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "High Score: " + (int)highScoreCount;   
		
	}
    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
