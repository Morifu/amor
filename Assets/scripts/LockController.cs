using UnityEngine;
using System.Collections;

public class LockController : MonoBehaviour {

	// Private fields
	SpriteRenderer sprite;
	BoxCollider2D collider;

	SpriteRenderer odrzwiaSprite;
	BoxCollider2D ramaCollider;

	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ();
		collider = GetComponent<BoxCollider2D> ();
		odrzwiaSprite = transform.parent.FindChild("odrzwia").GetComponent<SpriteRenderer> ();
		ramaCollider = transform.parent.FindChild("rama").GetComponent<BoxCollider2D> ();
	}

//	void OnTriggerEnter2D(Collider2D other) 
//	{
//		if(other.gameObject.CompareTag("Arrow"))
//		{
//			transform.parent.FindChild("odrzwia").GetComponent<SpriteRenderer>().enabled = true;
//		}
//	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject.CompareTag("Arrow"))
		{
			// show open door and turn off collider of rama
			odrzwiaSprite.enabled = true;
			ramaCollider.enabled = false;
			// hide lock sprite and turn off collider
			sprite.enabled = false;
			collider.enabled = false;
		}
	}
}
