using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
    CharacterController character;

	private float speed;

	// Use this for initialization
	void Start () 
	{
		character = GetComponent<CharacterController> ();

		speed = 10;
	}
	
	// Update is called once per frame
	void Update () 
	{
        
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
}
