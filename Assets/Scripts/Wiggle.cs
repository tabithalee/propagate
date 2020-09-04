using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wiggle : MonoBehaviour {

	[SerializeField] float magnitude = 9f;
	[SerializeField] float offset = 0f;
	[SerializeField] float period = 5f;


	// Update is called once per frame
	void Update () {
		if (period <= Mathf.Epsilon)
		{
			return;
		}

		float cycles = Time.unscaledTime / period; // grows continually from 0


		const float tau = Mathf.PI * 2;
		float rawSinWave = Mathf.Sin(cycles * tau);

		float rotationOffset = rawSinWave * magnitude + offset;
		transform.rotation = Quaternion.Euler(0f, 0f, rotationOffset);
	}
}
