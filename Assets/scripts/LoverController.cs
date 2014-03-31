using UnityEngine;
using System.Collections;

public class LoverController : MonoBehaviour {
	public float maxSpeed = 1f;
	bool facingRight = true;
	public float move;
	i

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//float move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		if (move> 0 && facingRight) 
			Flip ();
		else if (move< 0 && !facingRight) 
			Flip ();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *=-1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Arrow") {

			Vector3 position = transform.InverseTransformPoint(other.transform.position);
			if(position.x < 0)
				GoLeft();
			else if (position.x > 0)
				GoRight();
			other.transform.parent = transform;
		}
		else {
			move = 0;
		}
	}

	void GoLeft()
	{
		move = 1;
	}

	void GoRight()
	{
		move = -1;
	}
}















