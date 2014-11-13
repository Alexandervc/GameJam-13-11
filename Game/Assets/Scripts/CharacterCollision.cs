using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour {
	public LevelManager levelManager;

	private Element playerElement;

	// Use this for initialization
	void Start () 
	{
		playerElement = GetComponent<CharacterAttack> ().GetElement ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other) 
	{
		/*switch(other.tag)
		{
			case "enemy": 
				levelManager.DecreaseLives(1);
				break;
			case "projectile":
			Element enemyElement = other.gameObject.GetComponent<Projectile>().GetElement();
			switch(playerElement)
			{
				//Projectile projectileInstantiate(projectilePrefab);
			case Element.air:
				switch(enemyElement)
				{

				}
				// do normal
				break;
			case Element.earth:
				// earthquake
				break;
			case Element.fire:
				// fireball
				break;
			case Element.glass:
				// do normal
				break;
			case Element.normal:
				// do normal
				break;
			case Element.spirit:
				// take over
				break;
			case Element.water:
				// bubble cage
				break;
			}
					Destroy(other.gameObject);
					break;
				}*/
	}
}
