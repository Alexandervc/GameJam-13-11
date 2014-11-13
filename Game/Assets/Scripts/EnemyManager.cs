using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public CharacterController enemy;
	public string type;
	private int range;
	private float speed;
	private float position;
	private DirectionEnum direction;

	public ArrayList projectiles;
	private int count;

	// Use this for initialization
	void Start ()
	{
		projectiles = new ArrayList();
		count = 0;

		//walkingrange of enemy
		range = 5;
		position = 0;
		direction = DirectionEnum.right;

		if (type.Equals("earth"))
		{
			speed = 0.05f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (count == 100)
		{
			Projectile p = new Projectile(direction, 0.1f);
			projectiles.Add(p);
			count = 0;
		}

		count++;
		SetMovement();
	}

	private void SetMovement()
	{

		if(position <= 0)
		{
			position += speed;
			enemy.Move(new Vector3(speed, 0, 0));
			direction = DirectionEnum.right;
		}
		else if (position >= range)
		{
			position -= speed;
			enemy.Move(new Vector3(-speed, 0, 0));
			direction = DirectionEnum.left;
		}
		else if (position < range)
		{
			if(direction == DirectionEnum.right)
			{
				position += speed;
				enemy.Move(new Vector3(speed, 0, 0));
			}
			else if(direction == DirectionEnum.left)
			{
				position -= speed;
				enemy.Move(new Vector3(-speed, 0, 0));
			}
		}
	}
}

public enum DirectionEnum
{
	left,
	right
}
