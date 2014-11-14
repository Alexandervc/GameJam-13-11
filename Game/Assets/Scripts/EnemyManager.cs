using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	private Transform enemy;
	public Element element;
	private int range;
	private float speed;
	private float position;
	private DirectionEnum direction;
	
	private int count;
	public GameObject projObject;
	private GameObject projectile;
	private int number;
	private GameObject[] projectiles;
	private DirectionEnum[] directions;

	// Use this for initialization
	void Start ()
	{
		enemy = this.transform;
		count = 0;

		//walkingrange of enemy
		range = 5;
		position = 0;
		this.direction = DirectionEnum.right;

		projectile = null;
		number = 0;
		projectiles = new GameObject[5];
		directions = new DirectionEnum[5];

		if (element == Element.earth)
		{
			speed = 0.03f;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (count == 100)
		{
			projectiles[number] = (GameObject)Instantiate(projObject, GetProjectilePosition(), Quaternion.identity);
			directions[number] = this.direction;

			//Reset numbers
			switch (number)
			{
				case 0:
					Destroy(projectiles[1]);
					number++;
					break;
				case 1:
					Destroy(projectiles[2]);
					number++;
					break;
				case 2:
				    Destroy(projectiles[3]);
					number++;
					break;
				case 3:
				    Destroy(projectiles[4]);
					number++;
					break;
				case 4:
				    Destroy(projectiles[0]);
					number = 0;
					break;
			}

			count = 0;
		}
		else
		{
			for (int i=0; i<5; i++)
			{
				if (projectiles[i] != null)
				{
					if (directions[i] == DirectionEnum.right)
					{
						projectiles[i].transform.position = new Vector3(projectiles[i].transform.position.x + (speed * 1.5f), projectiles[i].transform.position.y, 0);
					}
					else if (directions[i] == DirectionEnum.left)
					{
						projectiles[i].transform.position = new Vector3(projectiles[i].transform.position.x - (speed * 1.5f), projectiles[i].transform.position.y, 0);
					}
				}
			}

			count++;
		}

		//Let enemy move around
		SetMovement();
	}

	private void SetMovement()
	{
		if(position <= 0)
		{
			position += speed;
			this.direction = DirectionEnum.right;
			enemy.position = new Vector3(enemy.position.x + speed, enemy.position.y, 0);
		}
		else if (position >= range)
		{
			position -= speed;
			this.direction = DirectionEnum.left;
			enemy.position = new Vector3(enemy.position.x - speed, enemy.position.y, 0);
		}
		else if (position < range)
		{
			if(this.direction == DirectionEnum.right)
			{
				position += speed;
				enemy.position = new Vector3(enemy.position.x + speed, enemy.position.y, 0);
			}
			else if(this.direction == DirectionEnum.left)
			{
				position -= speed;
				enemy.position = new Vector3(enemy.position.x - speed, enemy.position.y, 0);
			}
		}
	}

	private Vector3 GetProjectilePosition()
	{
		Vector3 pos = new Vector3(0,0,0);

		if (this.direction == DirectionEnum.left)
		{
			pos = new Vector3(enemy.position.x - 1.15f, enemy.position.y + 0.5f, 0);
		}
		else if (this.direction == DirectionEnum.right)
		{
			pos = new Vector3(enemy.position.x + 1.15f, enemy.position.y + 0.5f, 0);
		}

		return pos;
	}

	public Element GetElement()
	{
		return this.element;
	}
}

public enum DirectionEnum
{
	left,
	right
}
