using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	Rigidbody2D arrowBody;

	// Use this for initialization
	void Start() 
	{
		arrowBody = rigidbody2D;
		// Destroy the arrow after 2 seconds if it doesn't get destroyed before then.
		Destroy(gameObject, 2);

	}
	
	void FixedUpdate()
	{
		if (arrowBody.isKinematic)	return;

		Quaternion rot = Quaternion.LookRotation (arrowBody.velocity);
		// we don't need rotation on x and y within 2D space
		rot.x = 0;
		rot.y = 0;
		transform.rotation = rot;
		if(arrowBody.velocity.x < 0)
			transform.localScale = new Vector3(-1,1,1);
		else
			transform.localScale = new Vector3(1,1,1);

	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		arrowBody.fixedAngle = true;
		arrowBody.isKinematic = true;
		
	} 

}
