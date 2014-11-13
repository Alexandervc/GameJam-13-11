using UnityEngine;
using System.Collections;

public class InputDetection : MonoBehaviour {
	CharacterMovement character;

	void Start() 
	{
		character = GetComponent<CharacterMovement> ();
	}

	void Update() 
	{
		//Touch Input
		if(Input.touchCount == 1)
		{
			Touch touch = Input.touches[0];

			if(touch.position.x > (Screen.width / 2))
			{
				character.MoveRight();
			}
			else
			{
				character.MoveLeft();
			}
		}


		//Key Input
		if(Input.GetKeyDown(KeyCode.W))
		{

		}
		
		if(Input.GetKeyDown(KeyCode.A))
		{
			character.MoveLeft();
		}
		
		if(Input.GetKeyDown(KeyCode.S))
		{
			
		}
		
		if(Input.GetKeyDown(KeyCode.D))
		{
			character.MoveRight ();
		}
	}
}