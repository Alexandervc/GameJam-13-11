using UnityEngine;
using System.Collections;

public class MovingPlatformManager : MonoBehaviour {

	public enum PlatformType
	{
		platform,
		elevator
	}

	private Transform platform;
	public int range;
	private float position;
	public float speed;
	private DirectionEnum direction;
	public PlatformType platType;

	public CharacterCollision character;
	public Transform charTrans;

	// Use this for initialization
	void Start ()
	{
		platform = this.transform;
		position = 0;
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

			if (platType == PlatformType.platform)
			{
				platform.position = new Vector3(platform.position.x + speed, platform.position.y, 0);
			}
			else if (platType == PlatformType.elevator)
			{
				platform.position = new Vector3(platform.position.x, platform.position.y + speed, 0);
			}

			if (character.GetOnPlatform())
			{
				charTrans.position = new Vector3(charTrans.position.x + speed, charTrans.position.y, 0);
			}
		}
		else if (position >= range)
		{
			position -= speed;
			this.direction = DirectionEnum.left;

			if (platType == PlatformType.platform)
			{
				platform.position = new Vector3(platform.position.x - speed, platform.position.y, 0);
			}
			else if (platType == PlatformType.elevator)
			{
				platform.position = new Vector3(platform.position.x, platform.position.y - speed, 0);
			}

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

				if (platType == PlatformType.platform)
				{
					platform.position = new Vector3(platform.position.x + speed, platform.position.y, 0);
				}
				else if (platType == PlatformType.elevator)
				{
					platform.position = new Vector3(platform.position.x, platform.position.y + speed, 0);
				}

				if (character.GetOnPlatform())
				{
					charTrans.position = new Vector3(charTrans.position.x + speed, charTrans.position.y, 0);
				}
			}
			else if(this.direction == DirectionEnum.left)
			{
				position -= speed;

				if (platType == PlatformType.platform)
				{
					platform.position = new Vector3(platform.position.x - speed, platform.position.y, 0);
				}
				else if (platType == PlatformType.elevator)
				{
					platform.position = new Vector3(platform.position.x, platform.position.y - speed, 0);
				}
				
				if (character.GetOnPlatform())
				{
					charTrans.position = new Vector3(charTrans.position.x - speed, charTrans.position.y, 0);
				}
			}
		}
	}
}
