using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour {
	public LevelManager levelManager;

	public CharacterController character;
	private Element playerElement;
	private int livesBadAttack = 0;
	private int livesNormalAttack = 1;
	private int livesGreatAttack = 2;
	private bool onPlatform;

	// Use this for initialization
	void Start () 
	{
		onPlatform = false;
		playerElement = GetComponent<CharacterAttack> ().GetElement ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		print ("test");
		
		//Check if player touches ground
		if (hit.gameObject.tag.Equals("platform"))
		{
			if (character.isGrounded)
			{
				print ("im here");
				onPlatform = true;
				print (onPlatform);
			}
		}
		
		if (hit.gameObject.tag.Equals("ground"))
		{
			print ("im here2");
			onPlatform = false;
			print (onPlatform);
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		switch(other.tag)
		{
			case "enemy": 
				levelManager.DecreaseLives(livesNormalAttack);
				break;
			case "projectile":
				Element projectileElement = Element.air;
				//other.gameObject.GetComponent<Projectile>().GetElement();
				switch(playerElement)
				{
					//Projectile projectileInstantiate(projectilePrefab);
					case Element.air:
						this.handleProjCollision (projectileElement, Element.glass, Element.spirit);
						break;
					case Element.earth:
						this.handleProjCollision (projectileElement, Element.spirit, Element.water);
						break;
					case Element.fire:
						this.handleProjCollision (projectileElement, Element.water, Element.glass);
						break;
					case Element.glass:
						this.handleProjCollision (projectileElement, Element.fire, Element.air);
						break;
					case Element.normal:
						levelManager.DecreaseLives (livesNormalAttack);
						break;
					case Element.spirit:
						this.handleProjCollision(projectileElement, Element.air, Element.earth);
						break;
					case Element.water:
						this.handleProjCollision(projectileElement, Element.earth, Element.fire);
						break;
				}
				Destroy(other.gameObject);
				break;
		}
	}

	private void handleProjCollision(Element projectileElement, Element greatElement, Element badElement)
	{
		if (projectileElement == greatElement) 
		{
			levelManager.DecreaseLives (livesGreatAttack);
		} 
		else if (projectileElement == badElement) 
		{
			levelManager.DecreaseLives (livesBadAttack);
		} 
		else 
		{
			levelManager.DecreaseLives(livesNormalAttack);
		}
	}

	public bool GetOnPlatform()
	{
		return this.onPlatform;
	}
}
