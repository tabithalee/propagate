using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiggleTitle : MonoBehaviour {

	[SerializeField] float magnitude = 0.08f;
	[SerializeField] float offset = 0f;
	[SerializeField] float period = 3.8f;


	// Update is called once per frame
	void FixedUpdate () {
		if (period <= Mathf.Epsilon)
		{
			return;
		}

		float cycles = Time.unscaledTime / period; // grows continually from 0


		const float tau = Mathf.PI * 2;
		float rawSinWave = Mathf.Sin(cycles * tau);

		float rotationOffset = rawSinWave * magnitude + offset;
		transform.position += new Vector3(1f, -1f, 0f) * rotationOffset;
	}
}
