using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public UILabel livesText;
	public UILabel scoreText;

	private int lives = 3;
	private int score = 0;

	// Use this for initialization
	void Start () 
	{
		livesText.text = lives + "x";
		scoreText.text = "Score; " + score;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void DecreaseLives(int numberOfLives)
	{
		lives -= numberOfLives;
		livesText.text = lives + "x";
		if (lives == 0) 
		{
			GameOver();
		}
	}

	public void IncreaseScore(int numberOfScore)
	{
		score += numberOfScore;
		scoreText = "Score; " + score;
	}

	public void GameOver()
	{
		Application.LoadLevel (0);
	}
}

public enum Element
{
	earth,
	water,
	fire,
	glass,
	air,
	spirit,
	normal
}
