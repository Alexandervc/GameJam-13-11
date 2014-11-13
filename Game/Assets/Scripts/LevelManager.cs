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

	public void DecreaseLives()
	{
		lives--;
		livesText.text = lives + "x";
		if (lives < 0) 
		{
			print ("game over");
		}
	}
}
