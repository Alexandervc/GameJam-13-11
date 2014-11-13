using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform playerTransform;

    private Vector3 aimPos;
    private float smooth;

	// Use this for initialization
	void Start () {
        smooth = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
		//
        aimPos = playerTransform.position + (playerTransform.forward * -2.5f) + (playerTransform.up * 1.5f);
        transform.position = Vector3.Lerp(transform.position, aimPos, smooth);
        transform.LookAt(playerTransform);
	}
}
