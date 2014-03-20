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
		transform.Rotate (0, 0, -1);
	}

}
