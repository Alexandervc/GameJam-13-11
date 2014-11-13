using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public enum Direction
	{
		left,
		right
	}

	public Transform enemyTransform;
	public string type;
	private int range;
	private float speed;
	private float position;
	private Direction direction;

	// Use this for initialization
	void Start ()
	{
		//walkingrange of enemy
		range = 3;
		position = 0;
		direction = Direction.right;

		if (type.Equals("earth"))
		{
			speed = 0.1f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}

	private void Move ()
	{
		position = RoundFloat(position);
		print (position);

		if(position == 0)
		{
			print ("omdraaien begin");
			position += speed;
			this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, 0);
			direction = Direction.right;
		}
		else if (position == range)
		{
			print ("omdraaien eind");
			position -= speed;
			this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, 0);
			direction = Direction.left;
		}
		else if (position < range)
		{
			if(direction == Direction.right)
			{
				print ("loop rechts");
				position += speed;
				this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, 0);
			}
			else if(direction == Direction.left)
			{
				print ("loop links");
				position -= speed;
				this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, 0);
			}
		}
	}

	private float RoundFloat(float position)
	{
		print ("input; " + position);
		float count = position;
		count = count * 10;
		print ("x10; " + count);
		int round = Mathf.RoundToInt(count);
		print ("to int; " + round);
		count = round / 10;
		print ("/10" + count);
		return count;
	}
}
