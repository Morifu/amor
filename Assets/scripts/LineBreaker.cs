﻿using UnityEngine;
using System.Collections;

public class LineBreaker : MonoBehaviour {

	HingeJoint2D ring;

	// Use this for initialization
	void Start () {
		ring = GetComponent<HingeJoint2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.CompareTag("Arrow"))
		{
			ring.enabled = false;
		}
	}
}
