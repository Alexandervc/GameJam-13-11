using UnityEngine;
using System.Collections;

public class CharacterAttack : MonoBehaviour {
	public GameObject projectilePrefab;
	
	private Transform attackingEnemy;
	private Element playerElement;
	private bool sucking = false;
	private float suckTimer = 0f;
	private float endOfSuck = 6f;

	private Animator anim;
	private int transformHash = Animator.StringToHash ("Transform");
	private int suckHash = Animator.StringToHash("Suck");

	// Use this for initialization
	void Start () 
	{
		attackingEnemy = null;
		playerElement = Element.normal;
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (sucking && attackingEnemy != null) 
		{
			suckTimer += Time.deltaTime;
			if(suckTimer >= (endOfSuck / 2f))
			{
				// Destroy enemy
				Destroy (attackingEnemy.gameObject);
			}
			if(suckTimer >= endOfSuck)
			{
				// Transform
				anim.SetInteger ("Element", (int) playerElement);
				anim.SetTrigger(transformHash);
				attackingEnemy = null;
				sucking = false;
				suckTimer = 0f;
			}
		}
	}

	public void Attack(Transform enemyTransform)
	{
		Element enemyElement = enemyTransform.gameObject.GetComponent<EnemyManager>().GetElement();
		if(Vector2.Distance((Vector2) this.transform.position, (Vector2) enemyTransform.position) < 1f)
		{
			attackingEnemy = enemyTransform;
			this.playerElement = enemyElement;
			this.sucking = true;
			anim.SetTrigger (suckHash);
		}
		else
		{
			// Shoot new projectile!!
			// Set projectile element to playerElement
//			switch(playerElement)
//			{
				//Projectile projectileInstantiate(projectilePrefab);
//				case Element.air:
//					// do normal
//					break;
//				case Element.earth:
//					// earthquake
//					break;
//				case Element.fire:
//					// fireball
//					break;
//				case Element.glass:
//					// do normal
//					break;
//				case Element.normal:
//					// do normal
//					break;
//				case Element.spirit:
//					// take over
//					break;
//				case Element.water:
//					// bubble cage
//					break;
//			}
		}
	}

	public Element GetElement()
	{
		return this.playerElement;
	}

	public bool GetSucking()
	{
		return sucking;
	}
}
