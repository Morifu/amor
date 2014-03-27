using UnityEngine;
using System.Collections;

public class AnimationWoman1 : MonoBehaviour {
	public float maxSpeed = 1f;
	bool facingRight = true;
	public float move;

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
			move = -1;
		}
		else {
			move = 0;
		}
	}
}















