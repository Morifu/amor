using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public AudioClip arrowShotSound;
	public AudioClip arrowHitSound;

	Rigidbody2D arrowBody;
	CircleCollider2D arrowCollider;

	// Use this for initialization
	void Start() 
	{
		arrowBody = rigidbody2D;
		arrowCollider = GetComponent<CircleCollider2D> ();
		AudioHelper.CreatePlayAudioObject (arrowShotSound);
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
		Destroy(gameObject);
		arrowBody.fixedAngle = true;
		arrowBody.isKinematic = true;
		arrowBody.velocity = Vector2.zero;
		arrowCollider.enabled = false;
		 // we destroy as soon it hits anything as it creates problems
		if(!coll.gameObject.CompareTag("Lover"))
			AudioHelper.CreatePlayAudioObject (arrowHitSound);
	} 


}
