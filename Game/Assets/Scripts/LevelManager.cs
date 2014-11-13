using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public UILabel livesText;

	private int lives = 3;

	// Use this for initialization
	void Start () 
	{
		livesText.text = lives + "x";
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
