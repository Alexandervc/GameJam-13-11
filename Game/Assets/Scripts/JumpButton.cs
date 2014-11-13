using UnityEngine;
using System.Collections;

public class JumpButton : MonoBehaviour {

	CharacterMovement character;

	void Start(){
		character = GameObject.Find ("Character").GetComponent<CharacterMovement> ();
	}

	void OnClick(){
		character.Jump ();
	}
}
