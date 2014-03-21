using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Destroy the arrow after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);
	}

	
	void FixedUpdate()
	{
		Quaternion rot = Quaternion.LookRotation (rigidbody2D.velocity);
		// we don't need rotation on x and y within 2D space
		rot.x = 0;
		rot.y = 0;
		transform.rotation = rot;

	}

}
