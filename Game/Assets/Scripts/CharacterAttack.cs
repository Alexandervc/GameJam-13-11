using UnityEngine;
using System.Collections;

public class CharacterAttack : MonoBehaviour {
	public GameObject projectilePrefab;
	private Element playerElement;

	// Use this for initialization
	void Start () 
	{
		playerElement = Element.normal;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Attack(Transform enemyTransform)
	{
		Element enemyElement = enemyTransform.gameObject.GetComponent<EnemyManager>().GetElement();
		if(Vector2.Distance((Vector2) this.transform.position, (Vector2) enemyTransform.position) < 0.5f)
		{
			// suck up
			// play animation
			this.playerElement = enemyElement;
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
}
