using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Rigidbody projectile;
	private DirectionEnum direction;
	private float speed;

	public Projectile(DirectionEnum d, float speed)
	{
		direction = d;
		this.speed = speed;
	}

	// Use this for initialization
	void Start ()
	{
		if (direction == DirectionEnum.left)
		{
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		projectile.transform = new Vector3 (projectile.transform.x + speed, projectile.transform.y, 0);
	}
}
