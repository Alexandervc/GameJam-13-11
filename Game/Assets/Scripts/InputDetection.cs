using UnityEngine;
using System.Collections;

public class InputDetection : MonoBehaviour {
	CharacterMovement character;
	CharacterAttack charAttack;

	void Start() 
	{
		character = GetComponent<CharacterMovement> ();
		charAttack = GetComponent<CharacterAttack> ();
	}

	void Update() 
	{
		//Touch Input
		if(Input.touchCount == 1)
		{
			Touch touch = Input.touches[0];
			GameObject hit = this.CheckTouch(touch.position);
			if(hit != null && (hit.CompareTag("Player") || hit.CompareTag("enemy")) && touch.phase == TouchPhase.Began)
			{
				if(hit.CompareTag("Player"))
				{
					character.Jump ();
				}
				else if (hit.CompareTag("enemy"))
				{
					charAttack.Attack (hit.transform);
				}
			}
			else if(touch.position.x > (Screen.width - (Screen.width / 4)))
			{
				character.MoveRight();
			}
			else if(touch.position.x < (Screen.width / 4))
			{
				character.MoveLeft();
			}
		}

		//Key Input
		if(Input.GetKey(KeyCode.W))
		{
			character.Jump();
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			character.MoveLeft();
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			character.MoveRight ();
		}
	}

	private GameObject CheckTouch(Vector3 touchPosition)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(touchPosition);
		Vector3 touchPos = new Vector3(pos.x, pos.y, 0f);
		Collider[] hits = Physics.OverlapSphere (touchPos, 0f);
		if(hits.Length > 0)
		{
			return hits[0].gameObject;
		}
		return null;
	}
}