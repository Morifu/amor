using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {

	public Rigidbody2D arrow;	// Prefab of the arrow.
	public float speed = 5;		// The speed the arrow will fire at.
	
	
	private Animator anim;		// Reference to the Animator component.

	public void shootArrow( Vector2 direction )
	{
		// ... instantiate the arrow facing right and set it's velocity to the right. 
		Rigidbody2D arrowInstance = Instantiate(arrow, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		arrowInstance.velocity = direction*speed;

	}
}
