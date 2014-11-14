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
	private int number;
	private ProjectileManager[] scripts;

	private Animator anim;
	private int damageHash;

	private GameObject enemyType;
	public GameObject airEnemy;
	public GameObject earthEnemy;
	public GameObject fireEnemy;
	public GameObject glassEnemy;
	public GameObject spiritEnemy;
	public GameObject waterEnemy;

	// Use this for initialization
	void Start ()
	{
		enemy = this.transform;
		count = 0;
		
		//walkingrange of enemy
		range = 5;
		position = 0;
		this.direction = DirectionEnum.right;
		
		number = 0;
		scripts = new ProjectileManager[5];
		
		Vector3 pos = new Vector3(enemy.position.x + 0.5f, enemy.position.y + 0.5f, 0);
		
		print (element);
		
		if (element == Element.air)
		{
			speed = 0.03f;
			enemyType = (GameObject)Instantiate(airEnemy, pos, Quaternion.identity);
		}
		else if (element == Element.earth)
		{
			speed = 0.04f;
			enemyType = (GameObject)Instantiate(earthEnemy, pos, Quaternion.identity);
		}
		else if (element == Element.fire) 
		{
			speed = 0.04f;
			enemyType = (GameObject)Instantiate(fireEnemy, pos, Quaternion.identity);
		}
		else if (element == Element.glass)
		{
			speed = 0.02f;
			enemyType = (GameObject)Instantiate(glassEnemy, pos, Quaternion.identity);
		}
		else if (element == Element.spirit)
		{
			speed = 0.05f;
			enemyType = (GameObject)Instantiate(spiritEnemy, pos, Quaternion.identity);
		}
		else if (element == Element.water)
		{
			speed = 0.03f;
			enemyType = (GameObject)Instantiate(waterEnemy, pos, Quaternion.identity);
		}

		anim = GetComponentInChildren<Animator> ();
		damageHash = Animator.StringToHash("Damage")
		
		enemyType.transform.parent = enemy;
		enemy.localScale = new Vector3(1.5f, 1.5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (count == 100)
		{
			count = 0;
			GameObject pro = (GameObject)ScriptableObject.Instantiate(projObject, GetProjectilePosition(), Quaternion.identity);
			scripts[number] = new ProjectileManager(pro, number, this.direction, this.element, GetProjectilePosition());

			//Reset numbers
			switch (number)
			{
				case 0:
					if (scripts[1] != null)
					{
						scripts[1].DestroyObject();
					}
					number++;
					break;
				case 1:
					if (scripts[2] != null)
					{
						scripts[2].DestroyObject();
					}
					number++;
					break;
				case 2:
					if (scripts[3] != null)
					{
						scripts[3].DestroyObject();
					}
					number++;
					break;
				case 3:
					if (scripts[4] != null)
					{
						scripts[4].DestroyObject();
					}
					number++;
					break;
				case 4:
					if (scripts[0] != null)
					{
						scripts[0].DestroyObject();
					}
					number = 0;
					break;
			}
		}
		else
		{
			for (int i=0; i<5; i++)
			{
				if (scripts[i] != null)
				{
					if (!scripts[i].GetDestroyed() && scripts[i].GetProjectile() != null)
					{
						Transform trans = scripts[i].GetProjectile().transform;

						if (scripts[i].GetDirection() == DirectionEnum.right)
						{
							Vector3 v3 = new Vector3(trans.position.x + (speed * 1.5f), trans.position.y, 0);
							scripts[i].SetPosition(v3);
						}
						else if (scripts[i].GetDirection() == DirectionEnum.left)
						{
							Vector3 v3 = new Vector3(trans.position.x - (speed * 1.5f), trans.position.y, 0);
							scripts[i].SetPosition(v3);
						}
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
			pos = new Vector3(enemy.position.x - 1.2f, enemy.position.y + 0.5f, 0);
		}
		else if (this.direction == DirectionEnum.right)
		{
			pos = new Vector3(enemy.position.x + 1.2f, enemy.position.y + 0.5f, 0);
		}

		return pos;
	}

	public Element GetElement()
	{
		return this.element;
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("projectile"))
		{
			Destroy(other.gameObject);
			anim.SetTrigger (damageHash);
			StartCoroutine(DestroyEnemy());
		}
	}

	public void DestroyProjectiles()
	{
		for(int i=0; i<5; i++)
		{
			if (scripts[i] != null && !scripts[i].GetDestroyed())
			{
				scripts[i].DestroyObject();
			}
		}
	}

	private IEnumerator DestroyEnemy()
	{
		yield return new WaitForSeconds(0.4f);
		Destroy (this.gameObject);
	}
}

public enum DirectionEnum
{
	left,
	right
}
