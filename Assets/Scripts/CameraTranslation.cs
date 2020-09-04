using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslation : MonoBehaviour {

	public GameObject player;
	public Vector3 offset;
	public float speed = 2f;
	public float xRange = 6f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rawPos = Vector3.Lerp(transform.position, player.transform.position + offset,
			Time.deltaTime * speed);
		//transform.LookAt(player.transform.position + Vector3.up * (offset.y * .7f) );
		float clampedXPos = Mathf.Clamp(rawPos.x, -xRange, xRange);
		transform.position = new Vector3(clampedXPos, rawPos.y, rawPos.z);
	}
}
