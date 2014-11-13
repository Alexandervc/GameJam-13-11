using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	private int lives = 3;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void DecreaseLives()
	{
		lives--;
	}
}
