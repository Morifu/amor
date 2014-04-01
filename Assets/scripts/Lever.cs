using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Arrow"))
		   anim.SetTrigger("TurnOn");
	}
}
