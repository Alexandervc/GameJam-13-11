using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	private Transform enemy;
	public string type;
	private int range;
	private float speed;
	private float position;
	private DirectionEnum direction;
	
	private int count;
	public GameObject projObject;
	private GameObject projectile;

	// Use this for initialization
	void Start ()
	{
		enemy = this.transform;
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
		if (projectile != null)
		{
			while (count < 50)
			{
				projectile.transform.position = new Vector3 (projectile.transform.position.x + speed, projectile.transform.position.y, 0);
			}
		}

		if (count == 50)
		{
			projectile = (GameObject)Instantiate(projObject, GetProjectilePosition(), Quaternion.identity);
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
			direction = DirectionEnum.right;
			enemy.position = new Vector3(enemy.position.x + speed, enemy.position.y, 0);
		}
		else if (position >= range)
		{
			position -= speed;
			direction = DirectionEnum.left;
			enemy.position = new Vector3(enemy.position.x - speed, enemy.position.y, 0);
		}
		else if (position < range)
		{
			if(direction == DirectionEnum.right)
			{
				position += speed;
				enemy.position = new Vector3(enemy.position.x + speed, enemy.position.y, 0);
			}
			else if(direction == DirectionEnum.left)
			{
				position -= speed;
				enemy.position = new Vector3(enemy.position.x - speed, enemy.position.y, 0);
			}
		}
	}

	private Vector3 GetProjectilePosition()
	{
		if (direction == DirectionEnum.left)
		{
			return new Vector3(enemy.position.x - 1.15f, enemy.position.y, 0);
		}
		else if (direction == DirectionEnum.left)
		{
			return new Vector3(enemy.position.x + 1.15f, enemy.position.y, 0);
		}

		return new Vector3(0,0,0);
	}
}

public enum DirectionEnum
{
	left,
	right
}
