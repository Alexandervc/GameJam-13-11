using UnityEngine;
using System.Collections;

public class MovingPlatformManager : MonoBehaviour {

	private Transform platform;
	private int range;
	private float position;
	private float speed;
	private DirectionEnum direction;

	public CharacterCollision character;
	public Transform charTrans;

	// Use this for initialization
	void Start ()
	{
		platform = this.transform;
		range = 4;
		position = 0;
		speed = 0.02f;
		this.direction = DirectionEnum.right;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Move platform
		SetMovement();
	}

	private void SetMovement()
	{
		if(position <= 0)
		{
			position += speed;
			this.direction = DirectionEnum.right;
			platform.position = new Vector3(platform.position.x + speed, platform.position.y, 0);

			if (character.GetOnPlatform())
			{
				charTrans.position = new Vector3(charTrans.position.x + speed, charTrans.position.y, 0);
			}
		}
		else if (position >= range)
		{
			position -= speed;
			this.direction = DirectionEnum.left;
			platform.position = new Vector3(platform.position.x - speed, platform.position.y, 0);

			if (character.GetOnPlatform())
			{
				charTrans.position = new Vector3(charTrans.position.x - speed, charTrans.position.y, 0);
			}
		}
		else if (position < range)
		{
			if(this.direction == DirectionEnum.right)
			{
				position += speed;
				platform.position = new Vector3(platform.position.x + speed, platform.position.y, 0);

				if (character.GetOnPlatform())
				{
					charTrans.position = new Vector3(charTrans.position.x + speed, charTrans.position.y, 0);
				}
			}
			else if(this.direction == DirectionEnum.left)
			{
				position -= speed;
				platform.position = new Vector3(platform.position.x - speed, platform.position.y, 0);
				
				if (character.GetOnPlatform())
				{
					charTrans.position = new Vector3(charTrans.position.x - speed, charTrans.position.y, 0);
				}
			}
		}
	}
}
