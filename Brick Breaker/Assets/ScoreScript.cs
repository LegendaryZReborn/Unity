using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	private Text score;
	// Use this for initialization
	void Start () 
	{
		score = gameObject.GetComponent<Text> ();

		if(gameObject.name == "HighScore")
		{
			//Get the highscore saved in the player preferences first
			//If not there, set it instead
			if(PlayerPrefs.HasKey("HighScore"))
				GlobalData.HighScore = PlayerPrefs.GetInt("HighScore");
			else
			{
				PlayerPrefs.SetInt("HighScore", GlobalData.HighScore);
				PlayerPrefs.Save();
			}

			updateHighScore();
			GlobalData.Score = 0;
		}
		else 
		{
			updateScore();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void updateScore()
	{
		score.text = GlobalData.Score.ToString ();
	}

	public void updateHighScore()
	{
		if(GlobalData.HighScore < GlobalData.Score)
		{
			GlobalData.HighScore = GlobalData.Score;
			PlayerPrefs.SetInt("HighScore", GlobalData.HighScore);
			PlayerPrefs.Save();
		}

		score.text = GlobalData.HighScore.ToString ();

	}
}
