using UnityEngine;
using System.Collections;

public class LoverController : MonoBehaviour {

	// public variables
	public float maxSpeed = 1f;
	public float move;
	public int steps = 5;
	public float deathVelocity = 5.0f;

	// private variables
	int stepsCount = 0;
	bool died = false;
	bool arrived = false;
	bool facingRight = true;

	Animator anim;
	BoxCollider2D loverCollider;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if (anim == null)
			anim = GetComponentInChildren<Animator> ();
		if(transform.localScale.x > 0)
			facingRight = false;
		else
			facingRight = true;

		loverCollider = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//float move = Input.GetAxis("Horizontal");

		float velocityY = rigidbody2D.velocity.y;
		float velocityX = rigidbody2D.velocity.x;
		//Debug.Log ("Falling speed: " + velocityY);
		if (anim !=null)
		{
			anim.SetFloat("FallSpeed", Mathf.Abs (velocityY));
			anim.SetFloat("vSpeed",Mathf.Abs(velocityX));
		}
		if(died) return;
		if( velocityY < (-1)*deathVelocity)
		{
			died = true;
			anim.SetBool("Died",died);
		}
		if(arrived) return;

		if(stepsCount > 0)
		{
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
			stepsCount--;
		}
		else
		{
			move = 0;
		}

		if (move < 0 && facingRight) 
			Flip ();
		else if (move > 0 && !facingRight) 
			Flip ();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		if((facingRight && theScale.x > 0) || (!facingRight && theScale.x < 0) )
			theScale.x *=-1;

		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Arrow") {

			Vector3 position = transform.InverseTransformPoint(other.transform.position);
			position.x *= (transform.localScale.x>0)?1:-1;
			if(position.x < 0)
				GoRight();
			else if (position.x > 0)
				GoLeft();
				
			other.transform.parent = transform;
			other.gameObject.GetComponent<CircleCollider2D>().enabled = false;
		}
//		else {
//			move = 0;
//		}


	}

	public void LockLover()
	{
		arrived = true;
		move = 0;
		rigidbody2D.isKinematic = true;
		loverCollider.enabled = false;

	}

//	void OnTriggerEnter2D(Collider2D other) 
//	{
//		if (other.gameObject.tag == "MeetingPoint") {
//			arrived = true;
//			move = 0;
//			rigidbody2D.isKinematic = true;
//
//		}
//	}

	void GoLeft()
	{
		move = -1;
		stepsCount = steps;
	}

	void GoRight()
	{
		move = 1;
		stepsCount = steps;
	}
}















