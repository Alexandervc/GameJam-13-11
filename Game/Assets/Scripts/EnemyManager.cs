using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public enum Direction
	{
		left,
		right
	}
	public string type;
	private int range;
	private float speed;
	private float position;
	private Direction direction;

	// Use this for initialization
	void Start ()
	{
		//walkingrange of enemy
		range = 5;
		position = 0;
		direction = Direction.right;

		if (type.Equals("earth"))
		{
			speed = 0.05f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		SetMovement();
	}

	private void SetMovement()
	{

		if(position <= 0)
		{
			position += speed;
			//enemy.Move(new Vector3(speed, 0, 0));
			direction = Direction.right;
		}
		else if (position >= range)
		{
			position -= speed;
			//enemy.Move(new Vector3(-speed, 0, 0));
			direction = Direction.left;
		}
		else if (position < range)
		{
			if(direction == Direction.right)
			{
				position += speed;
				//enemy.Move(new Vector3(speed, 0, 0));
			}
			else if(direction == Direction.left)
			{
				position -= speed;
				//enemy.Move(new Vector3(-speed, 0, 0));
			}
		}
	}
}
