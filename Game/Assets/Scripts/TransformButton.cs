using UnityEngine;
using System.Collections;

public class TransformButton : MonoBehaviour {
	public Animator anim;

	private int transformHash = Animator.StringToHash("Transform");

	void OnClick(){
		int element = anim.GetInteger ("Element");

		element++;
		if(element > 6)
			element = 0;

		anim.SetTrigger (transformHash);
		anim.SetInteger("Element", element);
	}
}
