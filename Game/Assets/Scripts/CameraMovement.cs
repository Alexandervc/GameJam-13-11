using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform playerTransform;

	private int middleWidth;
	private float camY = 5f;
	private float camZ = -10f;

	// Use this for initialization
	void Start () 
	{
		middleWidth = Camera.main.ScreenToWorldPoint(Screen.width / 2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerTransform.position.x >= middleWidth) 
		{
			transform.position = new Vector3(playerTransform.position.x, camY, camZ);
		}
	}
}
