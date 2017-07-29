using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData : object {

	private static int MAXLIVES = 10;
	private static int lives = 0;
	private static int score = 0;
	private static int highScore = 0; 


	static public int Lives
	{
		get
		{ 
			return lives;
		}

		set 
		{
			lives = lives > MAXLIVES ? value: lives;
		}
	}

	static public int Score
	{
		get
		{ 
			return score;
		}

		set
		{
			score = value;
		}
	}

	static public int HighScore
	{
		get
		{ 
			return highScore;
		}

		set
		{
			highScore = value;
		}
	}
}
