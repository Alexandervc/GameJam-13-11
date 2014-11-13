using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    CharacterController character;

	private Vector3 gravityDirection = Vector3.zero;

	private float speed;
	private float jumpHeight;
	private float gravity;

	private bool jump;

	// Use this for initialization
	void Start () 
	{
		character = GetComponent<CharacterController> ();

		speed = 10;
		jumpHeight = 5;
		gravity = 3;

		jump = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(character.isGrounded)
		{
			Debug.Log(character.isGrounded);

			//Jump movement
			if(jump)
			{
				gravityDirection.y = jumpHeight;
				jump = false;
			}
		}

		//Gravity on character
		gravityDirection.y -= gravity * Time.deltaTime;
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
