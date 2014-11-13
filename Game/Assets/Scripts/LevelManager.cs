using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public UILabel livesText;

	private int lives = 3;

	// Use this for initialization
	void Start () 
	{
		livesText.Text = lives + "x";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void DecreaseLives()
	{
		lives--;
		livesText.Text = lives + "x";
		if (lives < 0) 
		{
			print ("game over");
		}
	}
}
