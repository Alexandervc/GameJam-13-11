using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public UILabel livesText;
	public UILabel scoreText;
	public CharacterMovement character;

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
			StartCoroutine(GameOver());
		}
	}

	public void IncreaseScore(int numberOfScore)
	{
		score += numberOfScore;
		scoreText.text = "Score; " + score;
	}
	public IEnumerator GameOver()
	{
		yield return new WaitForSeconds (1);
		Application.LoadLevel (0);
	}

	public IEnumerator Win()
	{
		character.Jump ();
		yield return new WaitForSeconds (3);
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
