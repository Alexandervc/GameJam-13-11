﻿using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    CharacterController character;

	private Vector3 moveDirection = Vector3.down;

	private float speed;
	private float jumpHeight;
	private float gravity;

	private bool jump;

	// Use this for initialization
	void Start () 
	{
		character = GetComponent<CharacterController> ();

		speed = 5;
		jumpHeight = 10;
		gravity = 15;

		jump = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(character.isGrounded)
		{
			//Jump movement
			if(jump)
			{
				moveDirection.y = jumpHeight;
				jump = false;
			}
		}

		//Gravity on character
		moveDirection.y -= gravity * Time.deltaTime;
		character.Move(moveDirection * Time.deltaTime);
	}

	//Moves the character to the right
	public void MoveRight()
	{
		character.Move (Vector3.right * Time.deltaTime * speed);
	}


	//Moves the character to the left
	public void MoveLeft()
	{
		character.Move (Vector3.left * Time.deltaTime * speed);
	}

	public void Jump()
	{
		if(character.isGrounded)
			jump = true;
	}
}
