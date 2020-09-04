using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodMovement : MonoBehaviour {

	//public bool isReleased = false;
	//public PlayerController player;

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "floor")
		{
			Rigidbody myRigidBody = GetComponent<Rigidbody>();
			Collider myCollider = GetComponent<Collider>();
			
			if (myRigidBody)
			{
				Destroy(myRigidBody);
				myCollider.isTrigger = true;
			}
		}
	}
	
}
