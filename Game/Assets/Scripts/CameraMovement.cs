using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform playerTransform;

	private float beginCam = 8.7f;
	private float endCam = 18.5f;
	private float camY = 5f;
	private float camZ = -10f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerTransform.position.x >= beginCam && playerTransform.position.x <) 
		{
			transform.position = new Vector3(playerTransform.position.x, camY, camZ);
		}
	}
}
