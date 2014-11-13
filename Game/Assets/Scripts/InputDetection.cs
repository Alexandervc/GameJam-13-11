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

			if(touch.position.x > (Screen.width - (Screen.width / 4)))
			{
				character.MoveRight();
			}
			else if(touch.position.x < (Screen.width / 4))
			{
				character.MoveLeft();
			}
		}


		//Key Input
		if(Input.GetKey(KeyCode.W))
		{
			character.Jump();
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			character.MoveLeft();
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			character.MoveRight ();
		}
	}
}