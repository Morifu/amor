using UnityEngine;
using System.Collections;

public class LineBreaker : MonoBehaviour {

	public GameObject attachedObject;
	HingeJoint2D ring;
	DistanceJoint2D distanceJoint;

	// Use this for initialization
	void Start () {
		ring = GetComponent<HingeJoint2D> ();
		distanceJoint = GetComponent<DistanceJoint2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.CompareTag("Arrow"))
		{
			ring.enabled = false;
			distanceJoint.enabled = false;
			attachedObject.GetComponent<DistanceJoint2D>().enabled = false;
		}
	}
}