using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public enum Direction
	{

	}

	public string name;
	private int range;
	private int speed;
	private float position;
	private 

	// Use this for initialization
	void Start ()
	{
		//walkingrange of enemy
		range = 10;
		position = 0;

		if (name.Equals("earth"))
		{
			speed = 1;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}

	private void Move ()
	{
		if(position <= range)
		{

		}
	}
}
