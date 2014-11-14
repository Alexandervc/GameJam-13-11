using UnityEngine;
using System.Collections;

public class CharacterAttack : MonoBehaviour {

	public GameObject projectilePrefab;

	public GameObject character;
	public CharacterMovement movement;
	private ProjectileManager[] scripts;
	private int number;
	private float timeStart;

	private Transform attackingEnemy;
	private Element playerElement;
	private bool sucking = false;
	private float endOfSuck = 0.6f;

	private Animator anim;
	private int transformHash = Animator.StringToHash ("Transform");
	private int suckHash = Animator.StringToHash("Suck");

	public GameObject airProjectile;
	public GameObject earthProjectile;
	public GameObject fireProjectile;
	public GameObject glassProjectile;
	public GameObject spiritProjectile;
	public GameObject waterProjectile;

	// Use this for initialization
	void Start () 
	{
		scripts = new ProjectileManager[5];
		number = 0;
		timeStart = 0;

		attackingEnemy = null;
		playerElement = Element.normal;
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(sucking && attackingEnemy != null)
		{
			attackingEnemy.position = Vector3.Lerp (attackingEnemy.position, transform.position, 0.5f);
		}
		//Shooting timer
		if (timeStart > 0)
		{
			if (Time.time > timeStart + 1f)
			{
				timeStart = 0;
			}
		}

		for (int i=0; i<5; i++)
		{
			if (scripts[i] != null)
			{
				if (!scripts[i].GetDestroyed() && scripts[i].GetProjectile() != null)
				{
					Transform trans = scripts[i].GetProjectile().transform;
					
					if (scripts[i].GetDirection() == DirectionEnum.right)
					{
						Vector3 v3 = new Vector3(trans.position.x + 0.05f, trans.position.y, 0);
						scripts[i].SetPosition(v3);
					}
					else if (scripts[i].GetDirection() == DirectionEnum.left)
					{
						Vector3 v3 = new Vector3(trans.position.x - 0.05f, trans.position.y, 0);
						scripts[i].SetPosition(v3);
					}
				}
			}
		}
	}

	public void Attack(Transform enemyTransform)
	{
		if(Vector2.Distance((Vector2) this.transform.position, (Vector2) enemyTransform.position) < 3f)
		{
			attackingEnemy = enemyTransform;
			this.sucking = true;
			StartCoroutine (this.destroyEnemy());
			anim.SetTrigger (suckHash);
		}
		else
		{
			print ("shoot");
			// Shoot new projectile
			// Set projectile element to playerElement
			if (timeStart == 0)
			{
				GameObject pro = null;
				
				if (playerElement == Element.air)
				{
					pro = (GameObject)ScriptableObject.Instantiate(airProjectile, GetProjectilePosition(), Quaternion.identity);
				}
				else if (playerElement == Element.earth)
				{
					pro = (GameObject)ScriptableObject.Instantiate(earthProjectile, GetProjectilePosition(), Quaternion.identity);
				}
				else if (playerElement == Element.fire) 
				{
					pro = (GameObject)ScriptableObject.Instantiate(fireProjectile, GetProjectilePosition(), Quaternion.identity);
				}
				else if (playerElement == Element.glass)
				{
					pro = (GameObject)ScriptableObject.Instantiate(glassProjectile, GetProjectilePosition(), Quaternion.identity);
				}
				else if (playerElement == Element.spirit)
				{
					pro = (GameObject)ScriptableObject.Instantiate(spiritProjectile, GetProjectilePosition(), Quaternion.identity);
				}
				else if (playerElement == Element.water)
				{
					pro = (GameObject)ScriptableObject.Instantiate(waterProjectile, GetProjectilePosition(), Quaternion.identity);
				}
				else if (playerElement == Element.normal)
				{
					pro = (GameObject)ScriptableObject.Instantiate(projectilePrefab, GetProjectilePosition(), Quaternion.identity);
				}
				
				scripts[number] = new ProjectileManager(pro, number, movement.GetDirection(), playerElement, GetProjectilePosition());
				timeStart = Time.time;
			
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
		}
	}

	private Vector3 GetProjectilePosition()
	{
		Vector3 pos = new Vector3(0,0,0);
		
		if (movement.GetDirection() == DirectionEnum.left)
		{
			pos = new Vector3(character.transform.position.x - 0.85f, character.transform.position.y - 0.1f, 0);
		}
		else if (movement.GetDirection() == DirectionEnum.right)
		{
			pos = new Vector3(character.transform.position.x + 0.85f, character.transform.position.y - 0.1f, 0);
		}
		
		return pos;
	}

	public Element GetElement()
	{
		return this.playerElement;
	}

	public bool GetSucking()
	{
		return sucking;
	}

	private IEnumerator destroyEnemy()
	{
		yield return new WaitForSeconds (endOfSuck / 2f);
		// Destroy enemy
		Element enemyElement = attackingEnemy.gameObject.GetComponent<EnemyManager>().GetElement();
		attackingEnemy.gameObject.GetComponent<EnemyManager> ().DestroyProjectiles ();

		playerElement = enemyElement;
		Destroy (attackingEnemy.gameObject);
		StartCoroutine (transformPlayer ());
	}

	private IEnumerator transformPlayer()
	{
		yield return new WaitForSeconds(endOfSuck / 2f);
		anim.SetInteger ("Element", (int) playerElement);
		anim.SetTrigger(transformHash);
		attackingEnemy = null;
		sucking = false;
	}
}
