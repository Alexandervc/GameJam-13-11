using UnityEngine;
using System.Collections;

public class TransformButton : MonoBehaviour {
	public Animator anim;

	private int transformHash = Animator.StringToHash("Transform");

	void OnClick(){
		int element = anim.GetInteger ("Element");
		//0 = Earth, 1 = Water, 2 = Fire, 3 = Glass, 4 = Air, 5 = Spirit, 6 = Normal

		element++;
		if(element > 6)
			element = 0;

		anim.SetTrigger (transformHash);
		anim.SetInteger("Element", element);
	}
}
