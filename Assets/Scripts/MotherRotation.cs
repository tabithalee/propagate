using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherRotation : MonoBehaviour {

	public GameObject target;

	public float rotationSpeedRange = 15f;

	float rotationSpeed;

	void Start()
	{
		rotationSpeed = Random.Range(-rotationSpeedRange, 0);
	}

	// Update is called once per frame
	void Update () {
		rotateMother();
	}

	private void rotateMother()
	{
		transform.RotateAround(target.transform.position, Vector3.up,
			 rotationSpeed * Time.deltaTime);
	}
}
