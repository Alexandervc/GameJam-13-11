using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour {
	public LevelManager levelManager;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("enemy")) 
		{
			print ("colliding enemy");
			levelManager.DecreaseLives();
			Destroy (other.gameObject);
		}
	}
}
